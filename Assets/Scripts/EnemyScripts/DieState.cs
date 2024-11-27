using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private bool IsDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public override State RunCurrentState()
    {
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
    }

    public bool GetDie()
    {
        return IsDead;
    }
}
