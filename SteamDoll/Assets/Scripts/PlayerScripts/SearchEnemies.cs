using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemies : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList;
    [SerializeField]
    private GameObject nowTarget;
    private PlayerControl playerCtrl;
    private PlayerAttackAnim playerAtkAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        nowTarget = null;
        playerCtrl = GetComponent<PlayerControl>();
        playerAtkAnim = GetComponent<PlayerAttackAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TargetOther()
    {
        if (enemyList.Count == 0)
        {
            nowTarget = null;
            return;
        }

        if (!playerAtkAnim.isCrossAttack || 
            !playerAtkAnim.isLongAttack) 
        {

        }
    }
}
