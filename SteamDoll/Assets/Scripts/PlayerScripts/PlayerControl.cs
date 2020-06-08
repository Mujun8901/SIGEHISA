using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float smooth;
    private bool isGround;
    public bool isWalk;
    public bool isRun;

    CharacterController controller;
    Animator animator;
    Vector3 moveDir;
    PlayerDamage pDamage;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        pDamage = GetComponent<PlayerDamage>();
        moveDir = Vector3.zero;
        isWalk = false;
        isRun = false;
}

    void Update()
    {
        if (pDamage.isDead)return;
        isGround = !controller.isGrounded;
        if (isGround)
        {
            IsGravity();
        }
        else
        {
            RotatePlayer();
            MovePlayer();
            JumpPlayer();
        }
        
        // 移動実行
        controller.Move(Time.deltaTime * moveDir);
        if (controller.isGrounded) moveDir.y = 0.0f;
        // アニメーション
        animator.SetBool("jump", isGround);
        if (Vector3.Magnitude(moveDir) > 0.1f && Vector3.Magnitude(moveDir) < 2f)
        {
            isWalk = true;
            isRun = false;
        }
        if(Vector3.Magnitude(moveDir) > 2f)
        {
            isRun = true;
            isWalk = false;
        }
        if(Vector3.Magnitude(moveDir) < 0.1f)
        {
            isWalk = false;
            isRun = false;
        }
        animator.SetBool("run", isRun);
        animator.SetBool("walk", isWalk);
    }

    void MovePlayer()
    {
        if (pDamage.isDead) return;

        // 横方向
        moveDir.x = Input.GetAxis("Horizontal") * speed;
        // 縦方向
        moveDir.z = Input.GetAxis("Vertical") * speed;
    }

    void JumpPlayer()
    {
        if (pDamage.isDead)return;
        
        // ジャンプ
        if (Input.GetButton("Jump"))
        {
            moveDir.y = jumpSpeed;
        }
        else
        {
            moveDir.y -= gravity * Time.deltaTime;
        }
    }

    void RotatePlayer()
    {
        if (pDamage.isDead) return;

        if (moveDir.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);
        }
    }

    void IsGravity()
    {
        moveDir.y -= gravity * Time.deltaTime;
    }
}
