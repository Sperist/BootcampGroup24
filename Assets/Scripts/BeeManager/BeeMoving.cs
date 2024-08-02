using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeMoving : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isBeeMoving;

    [SerializeField] private Transform transform1;
    [SerializeField] private Transform transform2;

    private bool isGoingTransform1 = false; // transform1 den harekete baþlayacak

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (isGoingTransform1)
        {
            float distanceToTarget = Vector3.Distance(transform.position, transform1.position);
            if (distanceToTarget <= 1f)
            {
                GoTransform2();
            }
            else
            {
                GoTransform1();
            }
        }
        else
        {
            float distanceToTarget = Vector3.Distance(transform.position, transform2.position);
            if (distanceToTarget <= 1f)
            {
                GoTransform1();
            }
            else
            {
                GoTransform2();
            }
        }


        if (agent.velocity.magnitude > 0.1f)
        {
            isBeeMoving = true;
        }
        else
        {
            isBeeMoving = false;
        }
    }

    private void GoTransform1()
    {
        agent.SetDestination(transform1.position);
        isGoingTransform1 = true;
    }

    private void GoTransform2()
    {
        agent.SetDestination(transform2.position);
        isGoingTransform1 = false;
    }
}
