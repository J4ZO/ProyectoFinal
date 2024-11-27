using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del jugador.
    public float attackRange = 1.5f; // Rango del ataque.
    public int attackDamage = 10; // Daño que el jugador inflige.
    public LayerMask enemyLayer; // Enemigos detectables.

    void Update()
    {
        // Ataque con clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Activar la animación de ataque
        animator.SetTrigger("AttackTrigger");

        // Detectar enemigos en el rango de ataque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        // Infligir daño a los enemigos detectados
        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Mostrar el rango del ataque en la vista de escena (opcional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
