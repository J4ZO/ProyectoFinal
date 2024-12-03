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
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speedMovement * Time.deltaTime * y);
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime * x);

    }

    // Update is called once per frame
    void Update()
    {
        /* x = Input.GetAxis("Horizontal");
         y = Input.GetAxis("Vertical");

         transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);
         transform.Translate(0, 0, y * Time.deltaTime * speedMovement, 0);*/

        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");

        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Saltar", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            animator.SetBool("TocoSuelo", true);
        }
        else
        {
            EstoyCayendo();

        }

    }
    public void EstoyCayendo()
    {
        animator.SetBool("TocoSuelo", true);
        animator.SetBool("Saltar", true);
    }
}