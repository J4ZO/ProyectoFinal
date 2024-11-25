using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private ChaseEnemy chase; // call attack state
    private DieState die;
    private bool isAttacking;
    private Coroutine attackCoroutine; 

    void Start()
    {
        chase = GetComponent<ChaseEnemy>();
    }
    public override State RunCurrentState()
    {
        if(isAttacking)
        {
            attackCoroutine ??= StartCoroutine(WaitAttack());
            return this; // Stay in attack state
        }
        else if(die. GetDie()) // Change Die State
        {
            return die;
        }
        else
        {
            if (attackCoroutine != null) // Stop coroutine if is not in the attack zone
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null; 
            }
            return chase; // Change chase state
        }
        
        
    }

    private IEnumerator WaitAttack()
    { 
        while (true) 
        {
            Debug.Log("Atacando al jugador");
            yield return new WaitForSeconds(1f); 
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        isAttacking = other.CompareTag("Player") ? true : false;
    }
    private void OnTriggerExit(Collider other) 
    {
        isAttacking = other.CompareTag("Player") ? false : true;
    }
}