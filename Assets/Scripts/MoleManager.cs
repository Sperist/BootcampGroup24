using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoleManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float startingDistance = 24;

    private Vector3 firstPosition;

    private NavMeshAgent agent;

    private bool isMoleMoving;

    [SerializeField] private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        firstPosition = transform.position;
    }

    void Update()
    {
        MoleAnim();

        float distanceToTarget = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToTarget <= startingDistance)
        {
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            agent.SetDestination(firstPosition);
        }


        if (agent.velocity.magnitude > 0.1f)
        {
            isMoleMoving = true;
        }
        else
        {
            isMoleMoving = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManagment.instance.ReloadScene();
        }
    }

    private void MoleAnim()
    {
        animator.SetBool("isMoleMove", isMoleMoving);
    }
}
