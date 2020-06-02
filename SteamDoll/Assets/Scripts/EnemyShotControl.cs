using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float speed;

    public int power;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Stage" || col.tag == "Player")
        {
            // エフェクトを入れる
            Destroy(this.gameObject);
        }       
    }
}
