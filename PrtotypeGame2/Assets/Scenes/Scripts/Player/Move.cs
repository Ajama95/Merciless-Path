using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 6.0f;
 
    public float jumpHeight = 9.0f;
    public ParticleSystem Dust;
    public Animator animator;
    public bool dead;
    bool left;
    bool right; 

   

   Rigidbody rb;
    GameObject cam;
    private SpriteRenderer sprite;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dead = false;

         right = true;
        left = false;
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        float Xmov = Input.GetAxis("Horizontal");
        //float Ymov = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.A) && left == false)
        {
            sprite.flipX = true;//flip sprite depedning on where the character is moving to
        }
        if (Input.GetKeyDown(KeyCode.A) && right == false)
        {
            sprite.flipX = true;
           
            right = true;
        }

        transform.position += new Vector3(Xmov, 0, 0) * Time.deltaTime * playerSpeed; //x axis movement

        ///pressing spacebar to jump
        if (Input.GetButtonDown("Jump") && groundedPlayer == true)
        {
            CreateDust();
            rb.AddForce(new Vector2(0, jumpHeight), (ForceMode)ForceMode2D.Impulse);
        }


        animator.SetFloat("Speed", Mathf.Abs(Xmov));
       

    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
    }

    public void OnCollisionEnter(Collision col)
    {
        //Check to see if the tag on the collider is equal to ground 
        if (col.collider.tag == "ground")
        {
            groundedPlayer = true; //prevents the player from jumping continously
            animator.SetBool("isJumping", false); //exit animation;
            CreateDust();
        }
        if (col.collider.tag == "End")
        {
            SceneManager.LoadScene("End");
        }

    }
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            groundedPlayer = false;
            animator.SetBool("isJumping", true);
        }

    }

       
    void CreateDust() 
    {
        Dust.Play();
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    private void OnDestroy()
    {
        
    }

}
