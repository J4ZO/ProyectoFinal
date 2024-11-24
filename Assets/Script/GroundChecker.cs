using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other) 
    {  if (other.gameObject.CompareTag("Ground")) 
        {
            playerController.SetIsGrounded(true); 
        } 
    }
    private void OnCollisionExit(Collision other) 
    { 
        if (other.gameObject.CompareTag("Ground")) 
        {
            playerController.SetIsGrounded(false); 
        } 
    }
}
