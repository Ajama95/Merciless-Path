using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_afterimage_pooling : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;

    private Queue<GameObject> availalbleObjects = new Queue<GameObject>(); //store objects



    public static P_afterimage_pooling Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        GrowPool();  //ensure some ready at start
    }

    private void GrowPool()
    {
        for(int i = 0; i< 10; i++)
        {
            var InstaceToADD = Instantiate(afterImagePrefab);
            InstaceToADD.transform.SetParent(transform);
            AddToPool(InstaceToADD);
        }
    }


    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availalbleObjects.Enqueue(instance);

    }

    public GameObject GetfromPool()
    {
        if (availalbleObjects.Count == 0)
        {
            GrowPool();
        }
        var instance = availalbleObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
