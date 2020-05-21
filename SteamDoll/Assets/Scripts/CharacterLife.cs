using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterLife : MonoBehaviour
{
    [SerializeField]
    private int life;
    [SerializeField]
    GameObject gameObject;

    public void LifeReduce(int power)
    {
        life -= power;
    }

    public void Death()
    {
        if (life < 0)
        {
            if (gameObject.tag == "Player")
            {
                // 死んで暗転、スポーン場所に飛ばされる
                Debug.Log("死んだ");
            }
            else if (gameObject.tag == "Enemy")
            {
                // 消滅
                Destroy(this.gameObject);
            }
        }
    }
}
