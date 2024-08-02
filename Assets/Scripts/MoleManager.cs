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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToTarget <= startingDistance)
        {
            agent.SetDestination(playerTransform.position);
        }

        else
        {
            agent.SetDestination(firstPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Level yeniden baþla
            //þýrýnga number sýfýrla
        }
    }
}
