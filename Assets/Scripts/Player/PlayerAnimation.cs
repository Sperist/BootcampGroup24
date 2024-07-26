using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        animator.SetBool("isWalk", PlayerController.instance.isWalking);
        animator.SetBool("isRun", PlayerController.instance.isRunning);
        animator.SetBool("isJump", PlayerController.instance.isJumping);
    }
}
