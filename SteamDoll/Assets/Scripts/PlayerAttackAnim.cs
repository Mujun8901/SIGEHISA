using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnim : MonoBehaviour
{
    Animator animator;
    private int combo;
    private float comboCut;
    private float count;
    private bool isCrossAttack;
    public bool isAttackCombo;
    [SerializeField]
    private float motionTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        combo = 0;
        comboCut = motionTime * 2;
        count = 0.0f;
        isCrossAttack = false;
        isAttackCombo = false;
    }

    // Update is called once per frame
    void Update()
    {
        CrossRangeAttack();
        LongRangeAttack();
    }

    public void CrossRangeAttack()
    {
        // これ以上過ぎたらコンボを切る
        if (count > comboCut)
        {
            combo = 0;
            count = 0;
            isAttackCombo = false;
        }
        else if (combo > 3) 
        {
            // コンボは3つまで
            combo = 0;
        }

        if (Input.GetButtonDown("Fire1") && !Input.GetButton("Fire2")) 
        {
            // モーション時間を超えたらコンボ攻撃をする(モーションが雑にならないように)
            if (count > motionTime)
            {
                combo++;
                count = 0;
            }
            else if (combo == 0)
            {
                combo++;
            }            
            isCrossAttack = true;
            isAttackCombo = true;
        }
        else
        {
            isCrossAttack = false;
        }

        // 攻撃初めたらカウント開始
        if (isAttackCombo) count += Time.deltaTime;

        // アニメーション
        animator.SetInteger("combo", combo);
        animator.SetBool("attack", isCrossAttack);
    }

    void LongRangeAttack()
    {
        if (Input.GetButtonDown("Fire2") && !Input.GetButton("Fire1")) 
        {
            Debug.Log("longrange");
        }
    }
}
