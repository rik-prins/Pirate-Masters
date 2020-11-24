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
    public GameObject winCanvas;
    private GameObject UICanvas;

    public float depth = 1f;
    public float floatAmount = 3f;

    public bool win;

    private float movementSpeed = 0.05f;
    private float distance = 0.3f;
    private float progress = 0f;
    public int level = 1;
    public int score = 1;
    public int currentScore = 0;
    public int bounty = 350;
    public int roundSurvived = 250;
    public int deaths;
    public int deathsScore = 1000;
    public int totalScore;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instance = this;

        distanceText = GameObject.Find("Distance").GetComponent<Text>();
        progressText = GameObject.Find("Progress").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
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
        winCanvas.transform.GetChild(0).gameObject.SetActive(true);
        //WinScreen.Instance.StartCoroutine(WinScreen.Instance.WinAnimation());
        win = true;
        //StartCoroutine(Calculations());

        //currentScore += score;
        roundSurvived *= level;
        //bounty *= 3;

        if (deaths > 0)
        {
            deathsScore /= deaths;
        }

        totalScore = currentScore + score + bounty + roundSurvived + deathsScore;
    }

    //private IEnumerator Calculate()
    //{
    //    Calculations();
    //    yield break;
    //}

    //private IEnumerator Calculations()
    //{
    //    currentScore += score;
    //    roundSurvived *= level;
    //    bounty *= 3;

    //    if (deaths > 0)
    //    {
    //        deathsScore /= deaths;
    //    }

    //    totalScore = currentScore + score + bounty + roundSurvived + deathsScore;
    //    yield return new WaitForSeconds(500);

    //    //currentScore = totalScore;
    //}
}