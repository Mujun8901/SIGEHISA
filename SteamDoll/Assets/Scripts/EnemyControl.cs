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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myTransform = transform;
        setWolk = false;
        enemySearchRadius = 20f;
        raycastLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject shots = Instantiate(shot) as GameObject;

        shots.transform.position = muzzle.position;
        
        Debug.Log("1");
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃B 拡散弾
    void Attack2()
    {
        GameObject shots = Instantiate(shot) as GameObject;

        shots.transform.position = muzzle.position;
        Debug.Log("2");
        // 攻撃を終了する
        nextAttack = false;
    }

    // 攻撃C 連射弾
    void Attack3()
    {
        GameObject shots = Instantiate(shot) as GameObject;

        shots.transform.position = muzzle.position;
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
}
