using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStageManager : MonoBehaviour
{
    GameObject panel;
    FadeScript fade;
    bool isInput = false;
    private void Start()
    {
        panel = GameObject.Find("Panel");
        fade = panel.GetComponent<FadeScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInput)
        {
            // ここに効果音

            // フェードアウト
            fade.FadeOut();
        }
        if (isInput && fade.alfa == 1) SceneManager.LoadScene("Title");
    }
    public void OnClick()
    {
        isInput = true;
    }
}
