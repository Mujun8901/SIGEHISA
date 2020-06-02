using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleControl : MonoBehaviour
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
        if (Input.anyKeyDown) isInput = true;
        if (isInput)
        {
            // ここに効果音

            // フェードアウト
            fade.FadeOut();
        }
        if (isInput && fade.alfa == 1) SceneManager.LoadScene("Main");
    }
}
