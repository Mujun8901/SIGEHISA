using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private float invincibleTime;
    [SerializeField]
    private int life;
    private float time;
    private bool isDamage;
    void Start()
    {
        isDamage = false;
    }

    void Update()
    {
        Death();
        DamageIntarval();
    }

    void DamageIntarval()
    {
        if (isDamage)
        {
            time += Time.deltaTime;
        }
        if (time > invincibleTime)
        {
            isDamage = false;
            time = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!isDamage)
        {
            if (col.tag == "Shot")
            {
                Debug.Log("PlayerHit");
                Destroy(col.gameObject);
                // エネミーに設定されたダメージが入る
                LifeReduce(1);
                // ここにダメージ受けたアニメーションを入れる
                
                isDamage = true;
            }
        }
    }

    void LifeReduce(int power)
    {
        life -= power;
    }

    void Death()
    {
        if (life < 0)
        {
            Debug.Log("死んだ");
            
        }
    }
}
