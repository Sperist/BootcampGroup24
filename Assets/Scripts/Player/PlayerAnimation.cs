using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Camera climbCamera;
    [SerializeField] private Camera playerCamera;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform startClimbPoint;
    [SerializeField] private Transform endClimbPoint;

    private bool isClimbingCoroutineRunning = false;

    void Update()
    {
        print(animator.speed);

        if (PlayerController.instance.isClimbing && !isClimbingCoroutineRunning)
        {
            StartCoroutine(ClimbAnimEndCheckCoroutine());
        }

        if(!PlayerCarrying.instance.isCarrying)
        {
            animator.SetBool("isWalk", PlayerController.instance.isWalking);
            animator.SetBool("isRun", PlayerController.instance.isRunning);
            animator.SetBool("isJump", PlayerController.instance.isJumping);
            animator.SetBool("isClimb", PlayerController.instance.isClimbing);
            animator.SetBool("isThrow", PlayerController.instance.isThrowing);
        }

        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isClimb", false);
            animator.SetBool("isThrow", false);

        }

            if (PlayerCarrying.instance.isCarrying &&!PlayerController.instance.isWalking)
                animator.speed = 0;

            else
                animator.speed = 1;
        
        animator.SetBool("isCarry", PlayerCarrying.instance.isCarrying);
        animator.SetBool("isFall", PlayerFalling.instance.isHanging);
        animator.SetBool("isGetUp", PlayerFalling.instance.isGettingUP);
    }

    private IEnumerator ClimbAnimEndCheckCoroutine()
    {
        climbCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);

        PlayerTakeStartClimbPoint();

        yield return new WaitForSeconds(5f);

        PlayerController.instance.isClimbing = false;

        yield return new WaitForSeconds(0.041f);

        PlayerTakeEndClimbPoint();

        yield return new WaitForSeconds(0.2f);

        ThrowSeed.instance.canThrow = true;
        print("Press T");
        isClimbingCoroutineRunning = true;
    }

    private void PlayerTakeStartClimbPoint()
    {
        transform.position = startClimbPoint.position;
        transform.rotation = startClimbPoint.rotation;
    }

    private void PlayerTakeEndClimbPoint()
    {
        transform.position = endClimbPoint.position;
        transform.rotation = endClimbPoint.rotation;
    }
}
