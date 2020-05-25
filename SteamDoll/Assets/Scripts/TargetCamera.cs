using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
	private GameObject objTarget;
	[SerializeField]
	private Vector3 offset;

	void Start()
	{
		this.objTarget = GameObject.Find("Player(Clone)");		
	}

	void LateUpdate()
	{
		transform.position = objTarget.transform.position + offset;
	}
}
