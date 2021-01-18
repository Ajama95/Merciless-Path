using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    float TrapDelay = 400f;
    bool TrapTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if(TrapTimer == true)
        {
            TrapDelay--;
        }
        
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            TrapTimer = true;
           
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && TrapDelay <=0)
        {
            Destroy(col.gameObject);                                      ///destroy object if it stays in the the collider
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            TrapTimer = false;
            TrapDelay = 400f;
            Debug.Log("reset trap");
        }//reset timers on exit will change this to on off instead of timer 
    }
}
