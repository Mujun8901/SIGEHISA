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

    CharacterController controller;
    Animator animator;
    Vector3 moveDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        moveDir = Vector3.zero;
    }

    void Update()
    {
        isGround = !controller.isGrounded;
        if (controller.isGrounded)
        {
            RotatePlayer();
            MovePlayer();
            JumpPlayer();
        }
        else
        {
            IsGravity();
        }
        
        // 移動実行
        controller.Move(Time.deltaTime * moveDir);
        if (controller.isGrounded) moveDir.y = 0.0f;
        // アニメーション
        animator.SetBool("jump", isGround);
        animator.SetFloat("speed", Vector3.Magnitude(moveDir));
    }

    void MovePlayer()
    {
        // 横方向
        moveDir.x = Input.GetAxisRaw("Horizontal") * speed;
        // 縦方向
        moveDir.z = Input.GetAxisRaw("Vertical") * speed;
    }

    void JumpPlayer()
    {
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
