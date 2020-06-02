using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirstSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] ePrefab;
    private int cnt;
    private int maxEnemies;

    
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        maxEnemies = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (maxEnemies > cnt)
        {
            int num = Random.Range(0, ePrefab.Length);
            Instantiate(ePrefab[num], transform.position, transform.rotation);
            cnt++;
        }
    }
}
