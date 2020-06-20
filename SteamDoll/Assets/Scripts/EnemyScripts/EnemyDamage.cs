using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private float invincibleTime;
    PlayerAttackAnim pAttack;
    GameObject player;
    public int lifeMax;
    public int life;
    private float time;
    private bool isDamage;
    public bool isDead;
    GameObject manager;
    ScoreManager scoreManager;

    void Start()
    {
        manager = GameObject.Find("ScoreManager");
        scoreManager = manager.GetComponent<ScoreManager>();
        player = GameObject.Find("Player(Clone)");
        pAttack = player.GetComponent<PlayerAttackAnim>();
        life = lifeMax;
        isDamage = false;
        isDead = false;
        
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
        if (col.tag == "Attack") 
        {
            LifeReduce(pAttack.attackDamage);
        }
        if(col.tag == "PlayerShot")
        {
            LifeReduce(pAttack.longAttackDamage);
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
            isDead = true;
        }

        if (isDead)
        {
            scoreManager.AddScore();
            // 敵を削除
            Destroy(this.gameObject);
        }
    }
}
