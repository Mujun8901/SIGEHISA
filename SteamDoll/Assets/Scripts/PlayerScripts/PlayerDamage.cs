using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private float invincibleTime;
    public int lifeMax;
    public int life;
    private float time;
    private bool isDamage;
    public bool isDead;
    GameObject panel;
    FadeScript fade;
    
    void Start()
    {
        panel = GameObject.Find("Panel");
        isDamage = false;
        isDead = false;
        fade = panel.GetComponent<FadeScript>();
        life = lifeMax;
    }

    void Update()
    {
        Death();
        DamageIntarval();
    }

    void DamageIntarval()
    {
        if (isDead) return;
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
        if (isDead) return;
        if (!isDamage)
        {
            if (col.tag == "EnemyShot")
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
        if (life <= 0)
        {
            Debug.Log("死んだ");
            // 死亡アニメーション(あれば)
            // 暗転
            fade.FadeOut();
            isDead = true;         
        }
    }
}
