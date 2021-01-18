using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    private bool groundedPlayer;
    public float Dashforce = -15.0f;
    private float DashForceBack = -6.0f;
    public float DashStartTime;
    public float CurrentDashTime;
    float dashDirection;
    float moveX;
    private bool isDashing;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        Dashmanager();

        ////Dash backwards by pressing q
        if (Input.GetKeyDown(KeyCode.Q) && groundedPlayer == true)
        {
            //sliding animation here
            rb.AddForce(new Vector2(DashForceBack, 0), (ForceMode)ForceMode2D.Impulse);
            
        }
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
    private void Dashmanager()
    {


        ///dash forward by pressing e
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //sliding animation here
            isDashing = true;
            CurrentDashTime = DashStartTime;
            dashDirection = (int)moveX;

           

        }

        if (isDashing)
        {
           
            rb.AddForce(new Vector2(Dashforce, 0), (ForceMode)ForceMode2D.Impulse);
            rb.drag = 40;
            CurrentDashTime -=Time.deltaTime;
        }
        if(CurrentDashTime <=0 && isDashing == true)
        {
            isDashing = false;
            rb.velocity = Vector3.zero;
            rb.drag = 0;
            rb.useGravity = true;
        }
       
    }
}
