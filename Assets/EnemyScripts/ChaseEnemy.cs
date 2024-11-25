using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : State
{
    [SerializeField] private Transform player;
    private DieState die;
    private NavMeshAgent agent;
    private AttackState attack; // call attack state

    [SerializeField] private bool isInRange;

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
        if(isInRange) // Change Attack State
        {
            return attack;
        }
        else if(die. GetDie()) // Change Die State
        {
            return die;
        }
        else
        {
            Debug.Log("Sigue persiguiendo"); // Stay in chase
            return this;
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        isInRange = other.CompareTag("Player") ? true : false;
    }
    private void OnTriggerExit(Collider other) 
    {
        isInRange = other.CompareTag("Player") ? false : true;
    }
}
