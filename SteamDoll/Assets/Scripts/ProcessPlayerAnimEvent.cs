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
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip footSoundHigh;
    [SerializeField]
    private AudioClip footSoundLow;
    [SerializeField]
    private AudioClip crossSe1;
    [SerializeField]
    private AudioClip crossSe2;
    [SerializeField]
    private AudioClip crossSe3;
    public float vol;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = vol;
    }

    void AttackStartLeftHand()
    {
        audioSource.PlayOneShot(crossSe1);
        capColLeftHand.enabled = true;
    }
    void AttackEndLeftHand()
    {
        capColLeftHand.enabled = false;
    }

    void AttackStartRightHand()
    {
        audioSource.PlayOneShot(crossSe2);
        capColRightHand.enabled = true;
        capColLeftHand.enabled = false;
    }
    void AttackEndRightHand()
    {
        capColRightHand.enabled = false;
    }

    void AttackStartFoot()
    {
        audioSource.PlayOneShot(crossSe3);
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

    void WalkSoundHigh()
    {
        audioSource.PlayOneShot(footSoundHigh);
    }

    void WalkSoundLow()
    {
        audioSource.PlayOneShot(footSoundLow);
    }

    void RunSoundHigh()
    {
        audioSource.PlayOneShot(footSoundHigh);
    }

    void RunSoundLow()
    {
        audioSource.PlayOneShot(footSoundLow);
    }
}
