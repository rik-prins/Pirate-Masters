using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canonball : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2000);
        Destroy(gameObject, 4);
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}