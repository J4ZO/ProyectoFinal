using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerAnimator : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotate = 200.0f;

    private Animator animator;
    public float x, y;
    public Rigidbody rb;

    public float fuerzaDeSalto = 22f;
    public float fuerzaExtra = 0.4f;
    public bool grounded;

    public float velocidadInicial;
    public float velocidadAgachado;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 8f;

    public GameObject arma;
    private bool armaActiva = false;

    public float rangoDeteccion = 5f;
    public LayerMask capaEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        velocidadInicial = speedMovement;
        velocidadAgachado = speedMovement * 0.5f;

        if (arma != null)
        {
            arma.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * speedRotate * 0.5f , 0);
            transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", y);

        // Si el jugador está atacando o no está en el suelo, no se realizan acciones
        if (!estoyAtacando && grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Salto
            {
                animator.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }

            // Cambiar el estado del arma al presionar R
            if (Input.GetKeyDown(KeyCode.R))
            {
                CambiarEstadoArma();
            }

            // Detecta los enemigos y ataca si es necesario
            if (DetectarEnemigo())
            {
                if (armaActiva)  // Si tiene el arma activa
                {
                    animator.SetTrigger("Arma");
                    AtacarConPistola();
                }
                else  // Si no tiene el arma, ataca con los puños
                {
                    animator.SetTrigger("Puños");
                    AtacarConPuños();
                }
            }
        }

        if (grounded)
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            Caigo();
        }
    }
    public void Caigo()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Salto", false);
    }
    private void AtacarConPistola()
    {
        estoyAtacando = true;

        // Lógica para disparar con la pistola
        Debug.Log("Disparando con la pistola");

        StartCoroutine(ResetAtaque());
    }

    private void AtacarConPuños()
    {
        estoyAtacando = true;

        // Lógica para golpear con los puños
        Debug.Log("Atacando con puños");

        StartCoroutine(ResetAtaque());
    }

    private void CambiarEstadoArma()
    {
        armaActiva = !armaActiva;

        if (arma != null)
        {
            arma.SetActive(armaActiva);
        }

        animator.SetBool("ArmaActiva", armaActiva);
    }

    private bool DetectarEnemigo()
    {
        Collider[] enemigos = Physics.OverlapSphere(transform.position, rangoDeteccion, capaEnemigos);
        return enemigos.Length > 0;
    }

    private IEnumerator ResetAtaque()
    {
        yield return new WaitForSeconds(1f); // Tiempo de duración del ataque
        estoyAtacando = false;
    }
    private void EstoyAtacando(bool estado)
    {
        animator.SetBool("IsAttacking", estado);
        estoyAtacando = estado;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el rango de detección en la vista de escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}