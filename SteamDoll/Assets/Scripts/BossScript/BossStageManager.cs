using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStageManager : MonoBehaviour
{
    GameObject panel;
    GameObject time;
    FadeScript fade;
    Timer timer;

    private void Start()
    {
        panel = GameObject.Find("Panel");
        time = GameObject.Find("Time");
        fade = panel.GetComponent<FadeScript>();
        timer = time.GetComponent<Timer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer.gameOver)
        {
            // ここに効果音

            // フェードアウト
            fade.FadeOut();
        }
        if (timer.gameOver && fade.alfa == 1) SceneManager.LoadScene("Title");
    }
}
