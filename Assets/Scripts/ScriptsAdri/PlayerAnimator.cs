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
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       /* x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speedMovement, 0);*/

        y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speedMovement * Time.deltaTime * y);

        x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime * x);
    }
}
