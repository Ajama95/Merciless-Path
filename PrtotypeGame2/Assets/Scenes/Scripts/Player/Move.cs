using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    public float jumpHeight = 9.0f;

   

   Rigidbody rb;
    GameObject cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Xmov = Input.GetAxis("Horizontal");
        //float Ymov = Input.GetAxisRaw("Vertical");


        transform.position += new Vector3(Xmov, 0, 0) * Time.deltaTime * playerSpeed; //x axis movement

        ///pressing spacebar to jump
        if (Input.GetButtonDown("Jump") && groundedPlayer == true)
        {
            rb.AddForce(new Vector2(0, jumpHeight), (ForceMode)ForceMode2D.Impulse);
        }


        
       

    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    private void OnCollisionEnter(Collision col)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (col.collider.tag == "ground")
        {
            groundedPlayer = true;
            Debug.Log("im grounded ");
        }

    }
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            groundedPlayer = false;
            Debug.Log("im grounded ");
        }

    }
       
}