using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    GameObject scoreManager;
    ScoreManager score;
    private Text scoreResult;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        score = scoreManager.GetComponent<ScoreManager>();
        scoreResult = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ResultScore();
    }

    void ResultScore()
    {
        score.Sort();
        Debug.Log(score.score[0]);
        scoreResult.text = "score\n\n"
                            + "1. " + score.score[0] + "\n\n"
                            + "2. " + score.score[1] + "\n\n"
                            + "3. " + score.score[2] + "\n\n"
                            + "4. " + score.score[3] + "\n\n"
                            + "5. " + score.score[4] + "\n\n";
    }
}
