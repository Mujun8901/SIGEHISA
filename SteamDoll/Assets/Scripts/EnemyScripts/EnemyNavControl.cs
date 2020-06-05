using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavControl : MonoBehaviour
{
    GameObject parent;
    Enemy3Control eneCon;
    public bool isGround;

    void Start()
    {
        parent = transform.root.gameObject;
        eneCon = parent.GetComponent<Enemy3Control>();
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
