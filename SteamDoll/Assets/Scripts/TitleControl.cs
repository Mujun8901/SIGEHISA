using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleControl : MonoBehaviour
{
    bool isInput = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isInput = true;
        }
        if (isInput)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
