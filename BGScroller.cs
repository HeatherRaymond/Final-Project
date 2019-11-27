﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private ParticleSystem ps;


    private Vector3 startPosition;
    public GameController playerScript;


    void Start()
    {
        GameObject gameController = GameObject.Find("GameController");

        playerScript.score = 0;

        startPosition = transform.position;


    }

    void Update()
    {
        startPosition = new Vector3(0, -10, 0);
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (playerScript.score >= 100)
        {
            scrollSpeed += Time.deltaTime * -2f;



        }

    }

}