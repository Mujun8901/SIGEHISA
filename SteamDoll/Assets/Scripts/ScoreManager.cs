using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int[] score = new int[6];
    public int scoreTmp;

    public static ScoreManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        scoreTmp = 0;
        if (Instance != null)
        {

            Debug.Log("re" + scoreTmp);
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
    public void AddScore()
    {
        scoreTmp += 100;
    }

    public void Sort()
    {
        int iterationNum = 0;
        score[5] = scoreTmp;
        for(int i= 0; i < score.Length; i++)
        {
            for(int j = 1; j < score.Length - i; j++)
            {
                iterationNum++;
                if (score[j] < score[j - 1])
                {
                    int temp = score[j];
                    score[j] = score[j - 1];
                    score[j - 1] = temp;
                }
            }
        }
    }
}
