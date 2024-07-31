using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Transform startClimbPoint;
    [SerializeField] private Transform endClimbPoint;
    void Update()
    {
        StartCoroutine(ClimbAnimEndCheckCoroutine());

        animator.SetBool("isWalk", PlayerController.instance.isWalking);
        animator.SetBool("isRun", PlayerController.instance.isRunning);
        animator.SetBool("isJump", PlayerController.instance.isJumping);
        animator.SetBool("isClimb", PlayerController.instance.isClimbing);
    }

    private IEnumerator ClimbAnimEndCheckCoroutine()
    {
        if (PlayerController.instance.isClimbing)
        {
            PlayerTakeStartClimbPoint();

            yield return new WaitForSeconds(5f);

            PlayerController.instance.isClimbing = false;
            
            print("anim bitti");

            yield return new WaitForSeconds(0.041f);

            PlayerTakeEndClimbPoint();
        }
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
