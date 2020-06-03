using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavControl : MonoBehaviour
{
    GameObject parent;
    EnemyControl eneCon;
    public bool isGround;

    void Start()
    {
        parent = transform.root.gameObject;
        eneCon = parent.GetComponent<EnemyControl>();
        isGround = false;
    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            isGround = true;
        }
    }
}
