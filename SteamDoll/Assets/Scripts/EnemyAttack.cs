using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 1.0f;
    EnemyControl eControl;


    void Start()
    {
        eControl = GetComponent<EnemyControl>();
    }

    void Update()
    {
        RangeToTarget();
    }
    
    // 範囲内にターゲットがいるかどうか→SetWalkがfalseになっているかどうか
    void RangeToTarget()
    {
        if (!eControl.setWolk)
        {

        }
    }

    // 攻撃A 砲撃
    void Attack1()
    {

    }

    // 攻撃B 拡散弾
    void Attack2()
    {

    }

    // 攻撃C 連射弾
    void Attack3()
    {

    }
    
    // アニメーション(共通)    
    // 攻撃のインターバル        
    void AttackInterval()
    {

    }

    // 攻撃したら場所移動するようにする(これはコントロールでやったほうがいいかも)
}
