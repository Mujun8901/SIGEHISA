using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform muzzle;
    public Transform target;
    public GameObject shot;
    public bool setWolk;
    private float enemySearchRadius;
    private Transform myTransform;
    public NavMeshAgent agent;
    private bool nextAttack = false;
    private float time = 0;
    private int move = 0;
    private LayerMask raycastLayer;
    EnemyDamage eDamage;

    private Quaternion fowardVec;


    void Start()
    {
        eDamage = GetComponent<EnemyDamage>();
        agent = GetComponent<NavMeshAgent>();
        myTransform = transform;
        setWolk = false;
        enemySearchRadius = 20f;
        raycastLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (eDamage.isDead) return;
        SearchForTorget();
        MoveForTorget();
        RangeToTarget();
    }

    public void SearchForTorget()
    {
        target = null;
        if (target == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere
                                       (myTransform.position, enemySearchRadius, raycastLayer);
            if (hitColliders.Length > 0)
            {
                int randomInt = Random.Range(0, hitColliders.Length);
                target = hitColliders[randomInt].transform;
            }
            else
            {
                RandomWolk();
            }
        } 
    }

    void MoveForTorget()
    {
        if (target != null)
        {
            SetNavDestination(target);
        }
    }

    void SetNavDestination(Transform dest)
    {
        agent.SetDestination(dest.position);
    }

    void RandomWolk()
    {
        if(!setWolk)
        {
            Vector3 myPos = myTransform.position;
            Vector2 randomPos = Random.insideUnitCircle * 20;
            agent.destination = myPos + new Vector3(randomPos.x, 0, randomPos.y);
            setWolk = true;
        }
        if (setWolk)
        {
            agent.SetDestination(agent.destination);
            if (agent.remainingDistance < agent.stoppingDistance) 
            {
                setWolk = false;
            }
        }
    }
    
    void RangeToTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere
                           (myTransform.position, enemySearchRadius, raycastLayer);

        if (agent.remainingDistance < agent.stoppingDistance && hitColliders.Length > 0)
        {
            int attack = 0;
            attack = Random.Range(0, 3);
            // 攻撃できるようになったら
            if (AttackInterval())
            {
                if (attack == 0)
                {
                    Attack1();
                }
                else if (attack == 1)
                {
                    Attack2();
                }
                else if (attack == 2) 
                {
                    Attack3();
                }
            }
            else
            {
                // インターバル中ランダムに動くか動かないか(0:動く　1:動かない)
                SmoothLookAt();
            }            
        }
        else
        {
            return;
        }
    }

    // 攻撃A 砲撃
    void Attack1()
    {
        StartCoroutine(this.CreateShot1());
        Debug.Log("1");
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃B 拡散弾
    void Attack2()
    {
        StartCoroutine(this.CreateShot2());
        Debug.Log("2");
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃C 連射弾
    void Attack3()
    {
        StartCoroutine(this.CreateShot3());
        Debug.Log("3");
        // 攻撃を終了する
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
                        Quaternion.LookRotation(target.position - transform.position),
                        0.1f);
    }

    IEnumerator CreateShot1()
    {
        GameObject.Instantiate(shot, muzzle.position, muzzle.rotation);
        yield return null;
    }

    IEnumerator CreateShot2()
    {
        for (int i = 0; i < 5; i++)
        {
            float angleX = Random.Range(-30f, 30f);
            float angleY = Random.Range(  0f, 15f);
            float angleZ = Random.Range(-30f, 30f);
            fowardVec = Quaternion.Euler(angleX, angleY, angleZ);
            GameObject.Instantiate(shot, muzzle.position, muzzle.rotation * fowardVec);
            yield return null;
        }
    }

    IEnumerator CreateShot3()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject.Instantiate(shot, muzzle.position, muzzle.rotation);
            yield return new WaitForSeconds(0.5f);
        }        
    }
}
