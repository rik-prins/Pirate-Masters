using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private Rigidbody rb;
    public float depth = 1f;
    public float floatAmount = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < 0f)
        {
            float sinkAmount = Mathf.Clamp01(-transform.position.y / depth) * floatAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * sinkAmount, 0f), ForceMode.Acceleration);
        }
    }
}