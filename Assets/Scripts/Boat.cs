using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public static Boat Instance;
    private Rigidbody rb;
    private Text distanceText;
    private Text progressText;

    public float depth = 1f;
    public float floatAmount = 3f;

    private float movementSpeed = 0.01f;
    private float distance = 5f;
    private float progress = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instance = this;

        distanceText = GameObject.Find("Distance").GetComponent<Text>();
        progressText = GameObject.Find("Progress").GetComponent<Text>();
    }

    private void Update()
    {
        if (progress <= distance)
        {
            progress += movementSpeed * Time.deltaTime;
        }

        progressText.text = progress.ToString("F1") + " /";
        distanceText.text = distance.ToString() + " Km";
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