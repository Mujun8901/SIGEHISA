using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Attack")
        {
            Debug.Log("Hit");
        }
    }
}
