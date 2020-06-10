using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private Transform muzzle;
    private Transform target;
    public GameObject shot;
    public bool setWolk;
    private bool nextAttack = false;
    private float time = 0;
    private bool isAttack;
    private Quaternion fowardVec;
    SummonEnemise summon;
    GameObject[] spawner;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip cannonSound;
    [SerializeField]
    private AudioClip shotGunSound;
    [SerializeField]
    private float cannonVol;
    [SerializeField]
    private float shotGunVol;

    void Start()
    {
        spawner = GameObject.FindGameObjectsWithTag("EnemySpawner");
        target = GameObject.Find("Player(Clone)").transform;
        isAttack = false;
        setWolk = false;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RangeToTarget();
        //transform.LookAt(target);
    }


    void RangeToTarget()
    {
        int attack;
        attack = Random.Range(0, 5);
        // 攻撃できるようになったら
        if (AttackInterval())
        {
            if (attack == 0)
            {
                Attack1();
                Debug.Log("Attack1");
            }
            else if (attack == 1)
            {
                Attack2();
                Debug.Log("Attack2");
            }
            else if (attack == 2)
            {
                Attack3();
                Debug.Log("Attack3");
            }
            else if (attack == 4)
            {
                SummonEnemise();
                Debug.Log("Attack4");
            }
        }
        else
        {
            SmoothLookAt();
        }
    }

    // 攻撃A 砲撃
    void Attack1()
    {
        StartCoroutine(this.CreateShot1());
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃B 拡散弾
    void Attack2()
    {
        StartCoroutine(this.CreateShot2());
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃C 連射弾
    void Attack3()
    {
        StartCoroutine(this.CreateShot3());
        // 攻撃を終了する
        nextAttack = false;
    }

    void SummonEnemise()
    {
        foreach(GameObject spawn in spawner)
        {
            spawn.GetComponent<SummonEnemise>().isSpawn = true;
        }
        nextAttack = false;
    }

    // アニメーション(共通)    
    // 攻撃のインターバル        
    bool AttackInterval()
    {
        // 一定時間経ったら
        if (time > waitTime && !nextAttack)
        {
            // 再度攻撃できる
            nextAttack = true;
            time = 0;
        }

        // タイムカウント
        time += Time.deltaTime;
        return nextAttack;
    }

    void SmoothLookAt()
    {

        transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        Quaternion.LookRotation(target.position - muzzle.position),
                        0.1f);

    }

    IEnumerator CreateShot1()
    {
        GameObject.Instantiate(shot, muzzle.position, muzzle.rotation);
        audioSource.volume = cannonVol;
        audioSource.PlayOneShot(cannonSound);
        yield return null;
    }

    IEnumerator CreateShot2()
    {
        for (int i = 0; i < 15; i++)
        {
            float angleX = Random.Range(-15f, 15f);
            float angleY = Random.Range(-15f, 15f);
            float angleZ = Random.Range(-15f, 15f);
            fowardVec = Quaternion.Euler(angleX, angleY, angleZ);
            GameObject.Instantiate(shot, muzzle.position, muzzle.rotation * fowardVec);
            yield return null;
        }
        audioSource.volume = shotGunVol;
        audioSource.PlayOneShot(shotGunSound);
    }

    IEnumerator CreateShot3()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject.Instantiate(shot, muzzle.position, muzzle.rotation);
            audioSource.volume = cannonVol;
            audioSource.PlayOneShot(cannonSound);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
