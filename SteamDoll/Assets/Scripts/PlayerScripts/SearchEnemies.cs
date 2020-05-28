using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemies : MonoBehaviour
{
    private GameObject nearObj;
    private PlayerAttackAnim pAttack;
    [SerializeField]
    private GameObject shotPos;
    private float searchTime = 0;

    void Start()
    {
        nearObj = null;
        pAttack = GetComponent<PlayerAttackAnim>();
    }

    void Update()
    {
        nearObj = serchTag(gameObject, "Enemy");
        if (nearObj == null) return;
        if (pAttack.isCrossAttack || pAttack.isLongAttack)
        {           
            shotPos.transform.LookAt(nearObj.transform);
        }
        SmoothLookAt();
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
                        Quaternion.LookRotation(nearObj.transform.position - transform.position),
                        0.1f);
    }
}
