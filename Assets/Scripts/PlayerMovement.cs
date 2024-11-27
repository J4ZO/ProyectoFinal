using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        // Movimiento.
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        if (direction.magnitude >= 0.1f)
            Move(direction);

        // Salto.
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }
    public void Move(Vector3 direction)
    {
        // Rotar hacia la dirección del movimiento.
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        // Aplicar movimiento.
        Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Prevenir saltos dobles.
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
