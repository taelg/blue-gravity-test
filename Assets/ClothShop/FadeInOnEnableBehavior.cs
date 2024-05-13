using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnEnableBehavior : MonoBehaviour
{

    [SerializeField] private Animator animator;

    private void OnEnable() {
        animator.Play(0);
    }
    
}
