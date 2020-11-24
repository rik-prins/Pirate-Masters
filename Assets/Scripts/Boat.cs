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
    private Text scoreText;
    private GameObject winCanvas;
    private GameObject UICanvas;

    public float depth = 1f;
    public float floatAmount = 3f;

    private float movementSpeed = 0.02f;
    private float distance = 5f;
    private float progress = 0f;
    private int score = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instance = this;

        distanceText = GameObject.Find("Distance").GetComponent<Text>();
        progressText = GameObject.Find("Progress").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        winCanvas = GameObject.Find("WinScreen");
        UICanvas = GameObject.Find("UI");
    }

    private void Update()
    {
        if (progress <= distance)
        {
            progress += movementSpeed * Time.deltaTime;
        }
        else
        {
            Win();
        }

        progressText.text = progress.ToString("F1") + " /";
        distanceText.text = distance.ToString() + " Km";
        scoreText.text = "Score: " + score.ToString("000000");
    }

    private void FixedUpdate()
    {
        if (transform.position.y < 0f)
        {
            float sinkAmount = Mathf.Clamp01(-transform.position.y / depth) * floatAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * sinkAmount, 0f), ForceMode.Acceleration);
        }
    }

    private void Win()
    {
        UICanvas.SetActive(false);
        winCanvas.SetActive(true);
    }
}