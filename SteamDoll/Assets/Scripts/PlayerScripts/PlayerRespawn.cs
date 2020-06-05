using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    GameObject panel;
    FadeScript fade;
    PlayerDamage pDamage;
    GameObject spawn;
    bool isDeth;

    void Start()
    {
        GameObject parent = GameObject.Find("Stage");
        spawn = parent.transform.Find("PlayerSpawnPoint").gameObject;
        panel = GameObject.Find("Panel");
        fade = panel.GetComponent<FadeScript>();
        pDamage = GetComponent<PlayerDamage>();
        isDeth = false;
    }

    void Update()
    {
        if (Input.GetButton("Jump") && pDamage.isDead)
        {
            RespawnPlayer();
        }

        if (isDeth) 
        {
            fade.FadeIn();
            if (fade.alfa < 0.7)
            {
                pDamage.isDead = false;
                if (fade.alfa == 0)
                {
                    isDeth = false;
                }
            }
        }
       
        
    }
    void RespawnPlayer()
    {
        if (fade.alfa != 1) return; 
        // まず体力をもとに戻す
        pDamage.life = pDamage.lifeMax;
        // リスポーン地点に戻す
        this.transform.position = spawn.transform.position;
        this.transform.rotation = spawn.transform.rotation;
        isDeth = true;
    }
}
