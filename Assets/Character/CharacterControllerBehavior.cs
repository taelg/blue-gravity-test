using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CharacterControllerBehavior : MonoBehaviour
{
    private readonly string ANIMATOR_HORIZONTAL_KEY = "horizontal_direction";
    private readonly string ANIMATOR_VERTICAL_KEY = "vertical_direction";

    [Header("Configurable")]
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Internal")]
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;

    private void FixedUpdate() {
        HandleMovementInputs();
    }

    private void HandleMovementInputs() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Move(horizontalInput, verticalInput);
        AnimateMovement(horizontalInput, verticalInput);
    }

    private void Move(float horizontalInput, float verticalInput) {
        rigidbody2d.velocity = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
    }

    private void AnimateMovement(float horizontalInput, float verticalInput) {
        animator.SetInteger(ANIMATOR_HORIZONTAL_KEY, (int) horizontalInput);
        animator.SetInteger(ANIMATOR_VERTICAL_KEY, (int) verticalInput);
    }


}
