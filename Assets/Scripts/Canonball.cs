﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonball : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(0, 500, 2000);
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}