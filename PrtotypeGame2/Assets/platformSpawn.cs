using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawn : MonoBehaviour
{
    public GameObject platform;
    private GameObject platformspawned;
    public Transform position;
    public float timeSpawned = 4f;
    public float respawntime = 3f;
    public bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawned--;
        if(spawned == false && timeSpawned<=0)
        {
            spawned = true; 
            platformspawned = Instantiate(platform, position) as GameObject;
          
            
        }
        if (spawned == true)
        {
            timeSpawned = 4f;
            spawned = false;
        }
        
    }
}
