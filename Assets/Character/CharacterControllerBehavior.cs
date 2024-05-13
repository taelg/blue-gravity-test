using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.U2D.IK;

public class CharacterBehavior : MonoBehaviour
{
    private readonly string ANIMATOR_HORIZONTAL_KEY = "horizontal_direction";
    private readonly string ANIMATOR_VERTICAL_KEY = "vertical_direction";

    [Header("Configurable")]
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Internal")]
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;
    [SerializeField] private AppearanceSlotBehavior hairSlot;
    [SerializeField] private AppearanceSlotBehavior clothSlot;
    [SerializeField] private AppearanceSlotBehavior hatSlot;

    private bool isInputBlockedByUI = false;

    private void FixedUpdate() {
        HandleMovementInputs();
    }

    private void HandleMovementInputs() {
        if (!isInputBlockedByUI) {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Move(horizontalInput, verticalInput);
            AnimateMovement(horizontalInput, verticalInput);
        }
    }

    private void Move(float horizontalInput, float verticalInput) {
        rigidbody2d.velocity = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
    }

    private void AnimateMovement(float horizontalInput, float verticalInput) {
        int horizontalInputRounded = (int) (horizontalInput > 0 ? Math.Ceiling(horizontalInput) : Math.Floor(horizontalInput));
        int verticalInputRounded = (int) (verticalInput > 0 ? Math.Ceiling(verticalInput) : Math.Floor(verticalInput));
        animator.SetInteger(ANIMATOR_HORIZONTAL_KEY, horizontalInputRounded);
        animator.SetInteger(ANIMATOR_VERTICAL_KEY, verticalInputRounded);
    }

    public void BlockInputDuringUI(bool block) {
        isInputBlockedByUI = block;
    }

    public Color GetHairColor() {
        return Color.white; //FIXME: this is a mock
    }

    public void SetHairColor(Color color) {
        hairSlot.SetColor(color);
    }

    public SpriteLibraryAsset GetHair() {
        return hairSlot.GetSpriteAsset();
    }

    public SpriteLibraryAsset GetCloth() {
        return clothSlot.GetSpriteAsset();
    }

    public SpriteLibraryAsset GetHat() {
        return hatSlot.GetSpriteAsset();
    }

    public void SetAppearance(SpriteLibraryAsset appearanceAsset, AppearanceSlot slotType) {
        switch (slotType) {
            case AppearanceSlot.Hair:
                SetHair(appearanceAsset);
            break;
            case AppearanceSlot.Cloth:
                SetCloth(appearanceAsset);
            break;
            case AppearanceSlot.Hat:
                SetHat(appearanceAsset);
            break;
            default:
                Debug.LogError("Unknown slotType: " + slotType.ToString());
            break;
        }
    }

    private void SetHair(SpriteLibraryAsset hairAsset) {
        hairSlot.SetSpriteAsset(hairAsset);
    }

    private void SetCloth(SpriteLibraryAsset clothAsset) {
        clothSlot.SetSpriteAsset(clothAsset);
    }

    private void SetHat(SpriteLibraryAsset hatAsset) {
        hatSlot.SetSpriteAsset(hatAsset);
    }

}
