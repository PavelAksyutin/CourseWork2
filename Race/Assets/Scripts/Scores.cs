using UnityEngine;
using UnityEngine.UI;
using System;

public class Scores : MonoBehaviour
{
	public Text UIArsenal2;
	private Controls controls;

	public GameObject player;

	void Start()
	{
		controls = player.GetComponent<Controls>();
	}

	void Update()
	{
		if(controls != null)
		{
			UIArsenal2.text = "Scores: " + Math.Floor(controls.scores);
		}
	}
}

