using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RemainingEnemy : MonoBehaviour
{
    GameObject[] remainingEnemy;
    GameObject panel;
    FadeScript fade;
    void Start()
    {
        panel = GameObject.Find("Panel");
        fade = panel.GetComponent<FadeScript>();
    }

    void LateUpdate()
    {
        remainingEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (remainingEnemy.Length < 1)
        {
            fade.FadeOut();

            if (fade.alfa == 1)
            {
                // シーン移動
                SceneManager.LoadScene("BossStage");
            }
        }
    }
}
