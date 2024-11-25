using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackPlayer : MonoBehaviour
{
    private DieState die;
    private bool isAttacking;
    private Coroutine attackCoroutine;  
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        die = enemy.GetComponent<DieState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking && attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(Attack());
        }
    
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isAttacking = true;  // Inicia el ataque cuando el jugador toca al enemigo
        }
    }


    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isAttacking = false;  // Detiene el ataque cuando el jugador deja de tocar al enemigo
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);  // Detenemos la corutina si deja de tocar
                attackCoroutine = null;  // Limpiamos la referencia
            }
        } 
    }  

    private IEnumerator Attack()
    {   
        while (isAttacking)
        {
            die.Damage(5f);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
