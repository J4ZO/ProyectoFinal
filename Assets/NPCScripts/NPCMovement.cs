using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agentNPC;
    [SerializeField] private float patrolTimer;
    [SerializeField] private float patrolWait;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private int wayPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        agentNPC = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if( agentNPC.remainingDistance <= agentNPC.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if(patrolTimer >= patrolWait)
            {
                if(wayPointIndex == wayPoints.Length - 1)
                {
                    wayPointIndex = 0;
                    patrolTimer = 0;
                }
                else
                {
                    wayPointIndex++;
                    patrolTimer = 0;
                }
            }
        }
        else
        {
            patrolTimer = 0;
        }

        agentNPC.destination = wayPoints[wayPointIndex].position;
    }
}
