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

    CharacterController controller;

    Vector3 moveDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveDir = Vector3.zero;
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            MovePlayer();
            JumpPlayer();
        }
        else
        {
            IsGravity();
        }

        // 移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDir);
        controller.Move(globalDirection * Time.deltaTime);
        if (controller.isGrounded) moveDir.y = 0.0f;
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
        Debug.Log("jump");
        if (Input.GetButton("Jump"))
        {
            moveDir.y = jumpSpeed;
        }
    }

    void IsGravity()
    {
        moveDir.y -= gravity * Time.deltaTime;
    }
}
