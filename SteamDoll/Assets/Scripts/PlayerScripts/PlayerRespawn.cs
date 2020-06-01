using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    GameObject panel;
    FadeScript fade;
    PlayerDamage pDamage;
    GameObject spawn;

    void Start()
    {
        GameObject parent = GameObject.Find("Stage");
        spawn = parent.transform.Find("PlayerSpawnPoint").gameObject;
        panel = GameObject.Find("Panel");
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
        this.transform.position = spawn.transform.position;
        pDamage.isDead = false;
    }
}
