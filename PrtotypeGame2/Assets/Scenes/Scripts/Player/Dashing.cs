using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    
    public float Dashforce;
    public float distanceBetweenImages;
    public float DashTime;
    public int Dashes = 3;
    public float DashStartTime;
    private float LastImageXpos;
    bool JustDashed;
    bool StopDash;
    private bool groundedPlayer;
    private bool isDashing;
    Vector3 Playervector;
    private int Direction;
    private float moveX;
    public float P_Drag;
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DashTime = DashStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        Dashmanager();

     
    }
    private void OnCollisionEnter(Collision col)
    {
        //Check to see if the tag on the collider is equal to ground
        if (col.collider.tag == "ground")
        {
            P_Drag = 0; //remove drag
            groundedPlayer = true;
            JustDashed = false;
            StopDash = false;
            Dashes = 2;
            //Debug.Log("im grounded ");
        }

    }
    private void Dashmanager()
    {
        if (Direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (moveX < 0 )
                {
                    Direction = 1;

                }
                else if (moveX > 0 )
                {
                    Dashes--;
                    Direction = 2;
                }
            }
        } else
        {
            if (DashTime <= 0)
            {
                Direction = 0;
                DashTime = DashStartTime;
                rb.velocity = Vector3.zero;
                Dashes--;
            }
            else
            {
                DashTime -= Time.deltaTime; //decrease time
                if (Mathf.Abs(transform.position.x - LastImageXpos) > distanceBetweenImages)
                {
                    LastImageXpos = transform.position.x;
                }
                if (Direction == 1 ) //dash depending on direction 
                {
                    rb.velocity = Vector2.left * Dashforce;
                    Dashes--;
                }
                else if (Direction == 2 )
                {
                    Dashes--;
                    rb.velocity = Vector2.right * Dashforce;
                    P_afterimage_pooling.Instance.GetfromPool();
                    LastImageXpos = transform.position.x;
                }
            }

        }

    }

    }


