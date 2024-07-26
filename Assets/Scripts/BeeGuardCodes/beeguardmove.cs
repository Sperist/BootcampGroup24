using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class beeguardmove : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;

    NavMeshAgent agent;
    GameObject currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = target1;
        SetNewDestination();
    }

    void Update()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentTarget = currentTarget == target1 ? target2 : target1;
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            agent.SetDestination(currentTarget.transform.position);
        }
    }
}
