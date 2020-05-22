using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    GameObject panel;
    FadeScript fade;
    Transform spawnPoint;
    PlayerDamage pDamage;

    void Start()
    {
        panel = GameObject.Find("Panel");
        spawnPoint = GetComponent<Transform>();
        fade = panel.GetComponent<FadeScript>();
        pDamage = GetComponent<PlayerDamage>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && pDamage.isDead)
        {
            RespawnPlayer();
        }

        if (!pDamage.isDead) fade.FadeIn();
    }
    void RespawnPlayer()
    {
        // まず体力をもとに戻す
        pDamage.life = pDamage.lifeMax;
        // リスポーン地点に戻す
        this.transform.position = spawnPoint.position;
        pDamage.isDead = false;
    }
}
