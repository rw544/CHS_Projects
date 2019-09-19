﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float yPos;
    public float xPos;
    public float zPos;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3(xPos, yPos, zPos);
        rb.transform.position += vector3;

    }

}