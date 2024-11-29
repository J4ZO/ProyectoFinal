using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackPlayer : MonoBehaviour
{
    private bool isAttacking;
    private DieState die;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        die = enemy.GetComponent<DieState>(); 
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {   
            die.Damage(5f);
        }
    }
}
