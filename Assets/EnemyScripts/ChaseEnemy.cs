using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : State
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private float distanceToAttack = 2f;

    private AttackState attack; // call attack state

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<AttackState>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    public override State RunCurrentState()
    {
        if(IsInRangeAttack())
        {
            return attack;
        }
        else
        {
            return this;
        }
        
    }


    private bool IsInRangeAttack()
    {
        float distanceAttack = Vector3.Distance(transform.position, player.position);

        if(distanceAttack <= distanceToAttack)
        {
            return true;
        }
        return false;
    }
}
