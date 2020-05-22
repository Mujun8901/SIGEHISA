using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstSpaen : MonoBehaviour
{
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    GameObject player;

    void Awake()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }
}
