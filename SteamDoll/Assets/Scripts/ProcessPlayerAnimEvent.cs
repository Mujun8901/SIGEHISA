using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessPlayerAnimEvent : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider capColLeftHand;
    [SerializeField]
    private CapsuleCollider capColRightHand;
    [SerializeField]
    private CapsuleCollider capColFoot;
    // Start is called before the first frame update
    void Start()
    {
    }

    void AttackStartLeftHand()
    {
        capColLeftHand.enabled = true;
    }
    void AttackEndLeftHand()
    {
        capColLeftHand.enabled = false;
    }

    void AttackStartRightHand()
    {
        capColRightHand.enabled = true;
        capColLeftHand.enabled = false;
    }
    void AttackEndRightHand()
    {
        capColRightHand.enabled = false;
    }

    void AttackStartFoot()
    {
        capColFoot.enabled = true;
        capColRightHand.enabled = false;
    }
    void AttackEndFoot()
    {
        capColFoot.enabled = false;
    }

    void Walk()
    {
        capColLeftHand.enabled = false;
        capColRightHand.enabled = false;
        capColFoot.enabled = false;
    }
}
