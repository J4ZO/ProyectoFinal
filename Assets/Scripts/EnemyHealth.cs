using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Salud máxima del enemigo.
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemigo recibió daño. Salud restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destruir al enemigo
        Debug.Log("Enemigo eliminado.");
        Destroy(gameObject);
    }
}

