using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facecamera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cam;
    float minDist;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector3(1f, 1f, 1f) * (cam.GetComponent<CameraOrbit>().distance - minDist) * 1.01f / 3;
        transform.rotation = cam.transform.rotation;
    }
}
