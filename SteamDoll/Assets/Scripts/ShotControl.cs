using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
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
}
