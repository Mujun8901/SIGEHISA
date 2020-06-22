using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResultContorol : MonoBehaviour
{
    GameObject panel;
    FadeScript fade;
    bool isInput = false;
    private AudioSource source;
    public AudioClip audio;
    public float vol;


    private void Start()
    {

        panel = GameObject.Find("Panel");
        fade = panel.GetComponent<FadeScript>();
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isInput = true;
            // ここに効果音
            source.PlayOneShot(audio);
        }

        if (isInput)
        {
            // フェードアウト
            fade.FadeOut();
        }
        if (isInput && fade.alfa == 1) SceneManager.LoadScene("Title");
    }
}
