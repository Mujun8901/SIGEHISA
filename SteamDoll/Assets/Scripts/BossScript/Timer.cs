using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField]
	private float time;
	public bool gameOver;

	void Start()
	{
		GetComponent<Text>().text = ((int)time).ToString();
		gameOver = false;
	}

	void Update()
	{
		time -= Time.deltaTime;

		if (time < 0)
		{
			time = 0;
			gameOver = true;
		}

		GetComponent<Text>().text = "燃料切れまで" + ((int)time).ToString() + "秒";
	}
}
