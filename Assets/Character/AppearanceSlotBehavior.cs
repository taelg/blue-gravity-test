using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[ExecuteAlways]
public class AppearanceSlotBehavior : MonoBehaviour
{


    [Header("Configurable")]
    [SerializeField] private SpriteLibraryAsset appearanceSprite;
    
    [Header("Internal")]
    [SerializeField] private SpriteRenderer idleFacingDown;
    [SerializeField] private SpriteRenderer idleFacingLeft;
    [SerializeField] private SpriteRenderer idleFacingRight;
    [SerializeField] private SpriteRenderer idleFacingUp;
    [SerializeField] private SpriteRenderer[] movingDownSprites;
    [SerializeField] private SpriteRenderer[] movingLeftSprites;
    [SerializeField] private SpriteRenderer[] movingRightSprites;
    [SerializeField] private SpriteRenderer[] movingUpSprites;

    private SpriteLibraryAsset previousClothSprites;

    private void Update() {
        UpdateClothOnInspectorChange();
    }

    public SpriteLibraryAsset GetSpriteAsset() {
        return appearanceSprite;
    }

    public void SetSpriteAsset(SpriteLibraryAsset appearanceSprite) {
        this.appearanceSprite = appearanceSprite;
        idleFacingDown.sprite = appearanceSprite.GetSprite("idle", "facing_down");
        idleFacingLeft.sprite = appearanceSprite.GetSprite("idle", "facing_left");
        idleFacingRight.sprite = appearanceSprite.GetSprite("idle", "facing_right");
        idleFacingUp.sprite = appearanceSprite.GetSprite("idle", "facing_up");
        PopulateClothSpriteRenderers(movingDownSprites, "moving_down");
        PopulateClothSpriteRenderers(movingLeftSprites, "moving_left");
        PopulateClothSpriteRenderers(movingRightSprites, "moving_right");
        PopulateClothSpriteRenderers(movingUpSprites, "moving_up");
    }

    public void SetColor(Color color) {
        idleFacingDown.color = color;
        idleFacingLeft.color = color;
        idleFacingRight.color = color;
        idleFacingUp.color = color;
        ColorizeClothSpriteRenderers(movingDownSprites, color);
        ColorizeClothSpriteRenderers(movingLeftSprites, color);
        ColorizeClothSpriteRenderers(movingRightSprites, color);
        ColorizeClothSpriteRenderers(movingUpSprites, color);
    }

    private void PopulateClothSpriteRenderers(SpriteRenderer[] spriteRenderers, string category) {
        int index = 0;
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            if (index < spriteRenderers.Length) {
                spriteRenderers[index].sprite = appearanceSprite.GetSprite(category, "frame_"+ index++);
            } else {
                Debug.LogWarning("Appearance animations are currently fixed to function with a number of 6 frames");
            }
        }
        
        if (index != spriteRenderers.Length) {
                Debug.LogWarning("Appearance animations are currently fixed to function with a number of 6 frames");
        }
    }

    private void ColorizeClothSpriteRenderers(SpriteRenderer[] spriteRenderers, Color color) {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.color = color;
        }
    }

    private void UpdateClothOnInspectorChange() {
        bool changedCloths = previousClothSprites != appearanceSprite;
        if (changedCloths) {
            previousClothSprites = appearanceSprite;
            SetSpriteAsset(appearanceSprite);
        }
    }
    private void OnDrawGizmos() { //Allow to update Appearance changes on editor time
        #if UNITY_EDITOR
            if (!Application.isPlaying) {
               UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
               UnityEditor.SceneView.RepaintAll();
            }
        #endif
    }

}
