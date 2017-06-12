using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To : MonoBehaviour 
{
	// Variables
	public GameObject target;

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Bullet");
	}

	// Update is called once per frame
	void Update () 
	{
		if (target.GetComponent<Bullet_Controller> ().trailActive = false) 
		{
			transform.position = target.transform.position;
		}
	}
}
