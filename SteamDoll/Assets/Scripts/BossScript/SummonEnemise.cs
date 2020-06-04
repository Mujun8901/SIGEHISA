using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemise : MonoBehaviour
{
    [SerializeField]
    GameObject[] ePrefab;
    private int cnt;
    private int maxEnemies;
    public bool isSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        maxEnemies = 2;
        isSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawn)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (maxEnemies > cnt)
        {
            int num = Random.Range(0, ePrefab.Length);
            Instantiate(ePrefab[num], transform.position, transform.rotation);
            cnt++;
        }
        else
        {
            cnt = 0;
            isSpawn = false;
        }
    }
}
