using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    public bool setWolk;
    private float enemySearchRadius;
    private Transform myTransform;
    public NavMeshAgent agent;

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
            Debug.Log("setWolk");
        }
        if (setWolk)
        {
            Debug.Log("stop");
            agent.SetDestination(agent.destination);
            if (agent.remainingDistance < 5) 
            {
                setWolk = false;
            }
        }
    }
}
