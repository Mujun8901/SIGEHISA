using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
	private GameObject objTarget;
	private Vector3 offset;

	void Start()
	{
		this.objTarget = GameObject.Find("Player");
		offset = transform.position - objTarget.transform.position;
	}

	void LateUpdate()
	{
		transform.position = objTarget.transform.position + offset;
	}
}
