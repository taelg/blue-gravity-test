using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CharacterControllerBehavior : MonoBehaviour
{
    private readonly string ANIMATOR_HORIZONTAL_KEY = "horizontal_direction";
    private readonly string ANIMATOR_VERTICAL_KEY = "vertical_direction";

    [Header("Base Stats")]
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Internal")]
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;


    void Start()
    {
                
    }

    void Update()
    {
        HandleMovementInputs();
        
    }

    private void HandleMovementInputs() {
        
        float horizontalInput = GetNormalizedInputAxis("Horizontal");
        float verticalInput = GetNormalizedInputAxis("Vertical");

        rigidbody2d.velocity = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        
        animator.SetInteger(ANIMATOR_HORIZONTAL_KEY, GetDirectionByInput(horizontalInput));
        animator.SetInteger(ANIMATOR_VERTICAL_KEY, GetDirectionByInput(verticalInput));
    }

    private float GetNormalizedInputAxis(string axisName) {
        float rawInput = Input.GetAxis(axisName);
        bool inputNearZero = rawInput < 0.05f && rawInput > -0.05f;
        return inputNearZero ? 0 : rawInput;
    }
    
    private int GetDirectionByInput(float input) {
        bool inputNearZero = input < 0.05f && input > -0.05f;
        bool inputMovingRight = input > 0.05f;

        if (inputNearZero) {
            return 0;
        } else if (inputMovingRight) {
            return 1;
        } else {
            return -1;
        }
    }


}
