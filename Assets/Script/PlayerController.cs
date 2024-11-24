using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    public float jumpForce;
    private bool isGrounded;

    public float attackRange = 1.0f;
    public float attackDamage = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
         HandleMovement();
         HandleJump();
         HandleInteraction();
         HandleAttack();
         HandleCrouch();
    }
   
    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)

        { Vector3 direction = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized; 
          rb.velocity = new Vector3(direction.x * movementSpeed, rb.velocity.y, direction.z * movementSpeed);
        }
        
    }
    private void HandleJump() 
    { 
        if (Input.GetButtonDown("Jump") && isGrounded) 
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        } 
    }

    private void HandleInteraction()
    {
           
    }
    private void HandleAttack()
    {
        
    }

    private void HandleCrouch()
    {

    }   
    public void SetIsGrounded(bool grounded) 
    { 
        isGrounded = grounded;
    }
    
}



