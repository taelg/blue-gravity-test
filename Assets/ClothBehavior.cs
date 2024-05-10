using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[ExecuteAlways]
public class ClothBehavior : MonoBehaviour
{


    [Header("Configurable")]
    [SerializeField] private SpriteLibraryAsset clothSprites;
    
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

    public void SetSpriteLibraryAsset(SpriteLibraryAsset clothSprites) {
        this.clothSprites = clothSprites;
        idleFacingDown.sprite = clothSprites.GetSprite("idle", "facing_down");
        idleFacingLeft.sprite = clothSprites.GetSprite("idle", "facing_left");
        idleFacingRight.sprite = clothSprites.GetSprite("idle", "facing_right");
        idleFacingUp.sprite = clothSprites.GetSprite("idle", "facing_up");
        PopulateClothSpriteRenderers(movingDownSprites, "moving_down");
        PopulateClothSpriteRenderers(movingLeftSprites, "moving_left");
        PopulateClothSpriteRenderers(movingRightSprites, "moving_right");
        PopulateClothSpriteRenderers(movingUpSprites, "moving_up");
    }

    private void PopulateClothSpriteRenderers(SpriteRenderer[] spriteRenderers, string category) {
        int index = 0;
        foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
            if (index < spriteRenderers.Length) {
                spriteRenderers[index].sprite = clothSprites.GetSprite(category, "frame_"+ index++);
            } else {
                Debug.LogWarning("Cloth animations are currently fixed to function with a number of 6 frames");
            }
        }
        
        if (index != spriteRenderers.Length) {
                Debug.LogWarning("Cloth animations are currently fixed to function with a number of 6 frames");
        }
    }
    private void UpdateClothOnInspectorChange() {
        bool changedCloths = clothSprites != null && previousClothSprites != clothSprites;
        if (changedCloths) {
            previousClothSprites = clothSprites;
            SetSpriteLibraryAsset(clothSprites);
        }
    }
    private void OnDrawGizmos() { //Allow to update cloth changes on editor time
        #if UNITY_EDITOR
            if (!Application.isPlaying) {
               UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
               UnityEditor.SceneView.RepaintAll();
            }
        #endif
    }

}
