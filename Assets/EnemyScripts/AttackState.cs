using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private float distanceToChase = 2f;
    [SerializeField] private Transform player;
    private ChaseEnemy chase; // call attack state

    void Start()
    {
        chase = GetComponent<ChaseEnemy>();
    }
    public override State RunCurrentState()
    {
        if(IsInRangeChase() == false)
        {
            Debug.Log("Atacando");
            return chase;
        }
        return this;
    }

    private bool IsInRangeChase()
    {
        float distanceChase = Vector3.Distance(transform.position, player.position);

        if(distanceChase >= distanceToChase)
        {
            return true;
        }
        return false;
    }


}