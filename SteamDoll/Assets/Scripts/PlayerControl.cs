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
    private bool isGround;  // 地面との接触判定

    //CharacterController controller;
    Rigidbody rb;
    Animator animator;

    Vector3 moveDir;

    void Start()
    {
        // controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        moveDir = Vector3.zero;
        isGround = true;
    }

    void Update()
    {
        if(isGround)
        {
            RotatePlayer();
            MovePlayer();
            JumpPlayer();
        }
        else if(!isGround)
        {
            //IsGravity();       
        }

        // 移動実行
        rb.MovePosition(transform.position * Time.deltaTime + new Vector3(moveDir.z, moveDir.y, moveDir.z));
        if (isGround) moveDir.y = 0.0f;

        // アニメーション
        animator.SetBool("jump", isGround);
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

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("stay");
        isGround = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGround = false;
        Debug.Log("jump");
    }
}
