using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy_patrolling : MonoBehaviour
{
    public bool Patroling;
    private bool turn;

    public float speed;

    Rigidbody rb;

    public Transform p1;
    public Transform p2;
    private bool right;
    private bool left;
    public bool alive;
    private float deathtime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        right = true;
        left = false;
        alive = true;
        
        Patroling = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(right ==true)
        { 
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (left == true)
        {
            Debug.Log("wooo");

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        death();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "p1")
        {
            left = true;
            right = false;
            speed*= -1;
            transform.localRotation = Quaternion.Euler(0, 180, 0);  //flip sprite 
        }
        if (collision.tag == "p2")
        {
            right = true;
            left = false;
            speed *= -1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (collision.gameObject.tag == "Player") //activate trap when player enters
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void death()
    {
        if(alive == false)
        {
            deathtime -= Time.deltaTime;
        }
        if (deathtime<=0)
        {
            Destroy(this.gameObject); //kill andoid on death
        }
    }

     
}



