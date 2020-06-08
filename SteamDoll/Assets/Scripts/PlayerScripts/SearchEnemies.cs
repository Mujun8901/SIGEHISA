using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemies : MonoBehaviour
{
    private GameObject nearObj;
    private PlayerAttackAnim pAttack;
    private PlayerControl pCtrl;
    [SerializeField]
    private GameObject shotPos;
    PlayerDamage pDamage;

    void Start()
    {
        nearObj = null;
        pAttack = GetComponent<PlayerAttackAnim>();
        pCtrl = GetComponent<PlayerControl>();
        pDamage = GetComponent<PlayerDamage>();
    }

    void Update()
    {
        if (pDamage.isDead) return;
        nearObj = serchTag(gameObject, "Enemy");
        if (nearObj == null)
        {
            shotPos.transform.rotation = transform.rotation;
            return; 
        }


        if (Vector3.Distance(transform.position, nearObj.transform.position) < 15.0f && !pCtrl.isRun)
        {
            if (pAttack.isCrossAttack == true || pAttack.isLongAttack == true)
            {
                shotPos.transform.LookAt(nearObj.transform);
            }
            SmoothLookAt();
        }
        else
        {
            shotPos.transform.rotation = transform.rotation;
        }
    }

    GameObject serchTag(GameObject nowObj,string tagName)
    {
        float tmpDis = 0;
        float nearDis = 0;

        GameObject targetObj = null;
        
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obj.transform.position, nowObj.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obj;
            }
        }
        return targetObj;
    }

    void SmoothLookAt()
    {
        transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        Quaternion.LookRotation
                        (new Vector3(nearObj.transform.position.x - transform.position.x,
                        0, nearObj.transform.position.z - transform.position.z)),
                        0.1f);
    }
}
