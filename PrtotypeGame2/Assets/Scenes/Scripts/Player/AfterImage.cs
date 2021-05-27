using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{

    private Transform player;
    private SpriteRenderer sr;
    private SpriteRenderer playerSR;
    private Color color;

    [SerializeField]
    private float activetime = 0.1f;
    private float timeactivated;
    private float alpha;
    [SerializeField]
    private float alphaset = 0.8f;
    private float alphaMultiplyer = 0.85f;



    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaset;
        sr.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeactivated = Time.time;
    }


    private void Update()
    {
        alpha *= alphaMultiplyer;
        color = new Color(1f, 1f, 1f, alpha);
        sr.color = color;

        if (Time.time >= (timeactivated + activetime))
        {
            P_afterimage_pooling.Instance.AddToPool(gameObject);
        }

    }
}