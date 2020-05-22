using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float speed = 0.01f;
    public float alfa;
    public float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    public void FadeOut()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
        if (alfa > 1)
        {
            alfa = 1;
        }
    }

    public void FadeIn()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa -= speed;
        if (alfa < 0)
        {
            alfa = 0;
        }
    }
}
