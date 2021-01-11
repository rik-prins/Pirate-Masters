using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    private int child = 1;
    public static WinScreen Instance;
    private float t = 2f;

    private Text currentScore, levelScore, bounty, roundSurvived, deaths, totalScore;

    private void Start()
    {
        Instance = this;
        StartCoroutine(WinAnimation());

        // texts
        currentScore = transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>();
        levelScore = transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<Text>();
        bounty = transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<Text>();
        roundSurvived = transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<Text>();
        deaths = transform.GetChild(0).transform.GetChild(6).gameObject.GetComponent<Text>();
        totalScore = transform.GetChild(0).transform.GetChild(7).gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        transform.GetChild(0).transform.GetChild(child).gameObject.GetComponent<Text>().fontSize = (int)Mathf.Lerp(300, 50, t);
        t += 1f * Time.deltaTime;

        if (Boat.Instance.win == true)
        {
            if (currentScore.fontSize > 49)
            {
                currentScore.text = "Current score: " + Boat.Instance.currentScore;
            }
            if (levelScore.fontSize > 49)
            {
                levelScore.text = "Level score: " + Boat.Instance.score;
            }
            if (bounty.fontSize > 49)
            {
                bounty.text = "Bounty: " + Boat.Instance.bounty;
            }
            if (roundSurvived.fontSize > 49)
            {
                roundSurvived.text = "Round Survived(" + Boat.Instance.level + ") " + Boat.Instance.roundSurvived;
            }
            if (deaths.fontSize > 49)
            {
                deaths.text = "Deaths:(" + Boat.Instance.deaths + ") " + Boat.Instance.deathsScore;
            }
            if (totalScore.fontSize > 49)
            {
                totalScore.text = "TOTAL ScORE: " + Boat.Instance.totalScore;
            }
        }
    }

    public IEnumerator WinAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (Boat.Instance.win == true)
            {
                if (child <= 6)
                {
                    child += 1;
                    t = 0;
                }
            }
        }
    }

    public void NextLevel()
    {
        Boat.Instance.win = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Boat.Instance.UICanvas.SetActive(true);
        Boat.Instance.level += 1;
        Boat.Instance.currentScore = Boat.Instance.totalScore;
        Boat.Instance.score = 0;
        Boat.Instance.deaths = 0;
        Boat.Instance.distance *= 1.5f;
        Boat.Instance.progress = 0;
        child = 1;

        for (int i = 2; i < 8; i++)
        {
            transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Text>().text = " ";
            transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Text>().fontSize = 0;
        }
    }
}