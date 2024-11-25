using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackPlayer : MonoBehaviour
{
    private bool isAttacking;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isAttacking = true;  // Inicia el ataque cuando el jugador toca al enemigo
            StartCoroutine(Attack(other.gameObject));
        }
    }


    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isAttacking = false;  // Detiene el ataque cuando el jugador deja de tocar al enemigo
        } 
    }  

    private IEnumerator Attack(GameObject enemy)
    {   
        DieState die = enemy.GetComponent<DieState>(); 
        while (isAttacking)
        {
            if (die != null)
            {
                die.Damage(5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
