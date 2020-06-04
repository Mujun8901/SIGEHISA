using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotControl : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //エフェクトを入れる
            Destroy(this.gameObject);
        }
    }
}
