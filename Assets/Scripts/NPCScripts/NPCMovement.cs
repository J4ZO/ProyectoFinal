using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agentNPC;
    [SerializeField] private float patrolTimer;
    [SerializeField] private float patrolWait;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private int wayPointIndex = 0;
    private bool isMoving;

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
        if(agentNPC.remainingDistance <= agentNPC.stoppingDistance) // Check the remaining distance
        {
            patrolTimer += Time.deltaTime; // Increse the patrol time

            if(patrolTimer >= patrolWait)
            {
                wayPointIndex++; // Go to the other waypoint
                patrolTimer = 0;
            }

            if(wayPointIndex == wayPoints.Length)
            {
                wayPointIndex = 0; // In case the npc arrive to the last waypoint
            }
        }
        agentNPC.SetDestination(wayPoints[wayPointIndex].position);
    }
}
