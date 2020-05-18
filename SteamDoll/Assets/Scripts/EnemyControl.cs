using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform target;

    Animator animator;
    Vector3 moveDir;
    private bool setWolk;
    private int wolkCnt;
    private float enemySearchRadius;
    private Transform myTransform;
    private NavMeshAgent agent;

    private LayerMask raycastLayer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        myTransform = transform;
        moveDir = Vector3.zero;
        setWolk = false;
        enemySearchRadius = 5f;
        raycastLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SearchForTorget()
    {
        target = null;
        if (target == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(myTransform.position, enemySearchRadius, raycastLayer);
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

    }

    void RandomWolk()
    {
        if(!setWolk)
        {
            Vector3 myPos = myTransform.position;
            Vector2 randomPos = Random.insideUnitCircle * 20;
            agent.destination = myPos + new Vector3(randomPos.x, 0, randomPos.y);
            setWolk = true;
            Debug.Log("setWolk");
        }
        else if (setWolk)
        {
            Debug.Log("stop");
            agent.SetDestination(agent.destination);
            if (agent.remainingDistance < 2.5f) 
            {
                setWolk = false;
            }
        }
    }
}
