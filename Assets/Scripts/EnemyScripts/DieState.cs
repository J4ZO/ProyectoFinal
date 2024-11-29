using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    private ChaseEnemy chase;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float increase;
    private bool IsDead;

    void Start()
    {
        chase = GetComponent<ChaseEnemy>();
        currentHealth = maxHealth;
    }

    public override State RunCurrentState()
    {
        if(IsDead)
        {
            return chase;
        }
        return this;
    }

    public void Damage(float damage)
    {
        Debug.Log("Quitando vida");
        currentHealth -=damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0f)
        {
            Die();
            IsDead = true;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("Muerto enemigo");
        currentHealth = SetMaxHealth(increase);
    }

    public bool GetDie()
    {
        return IsDead;
    }

    private float SetMaxHealth(float increase)
    {
        return maxHealth += increase;
    }
}
