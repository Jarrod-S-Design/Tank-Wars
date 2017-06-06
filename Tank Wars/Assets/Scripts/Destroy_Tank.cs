﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Tank : MonoBehaviour 
{
	// Variables
	public GameObject tankMain;
	public GameObject particleSys;

	// Health
	public int health = 20;

	// Bullet Counter
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;

	// Accesses the Tank_Movement script to get at currentClip
	private Tank_Movement tankMovementScript;

	public bool bulletCounter1 = true;
	public bool bulletCounter2 = true;
	public bool bulletCounter3 = true;


	public void TakeDamage(int damageToTake)
	{
		health = health - damageToTake;
	}

	// Run on initialization
	void Start () 
	{
		tankMovementScript = tankMain.GetComponent<Tank_Movement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// When the tanks get shot they are destroyed
		if (health <= 0)  
		{
			Destroy (this.gameObject);
			particleSys.SetActive (true);
			return;
		}
		// Bullet Counter
		if (tankMovementScript.currentClip == 0)
		{
			bulletCounter1 = false;
			bulletCounter2 = false;
			bulletCounter3 = false;
		}
		else if (tankMovementScript.currentClip == 1)
		{
			bulletCounter1 = true;
			bulletCounter2 = false;
			bulletCounter3 = false;
		}
		else if (tankMovementScript.currentClip == 2)
		{
			bulletCounter1 = true;
			bulletCounter2 = true;
			bulletCounter3 = false;
		}
		else if (tankMovementScript.currentClip == 3)
		{
			bulletCounter1 = true;
			bulletCounter2 = true;
			bulletCounter3 = true;
		}

		// Turns off/on the bullet counters
		if (bulletCounter1 == false) 
		{
			bullet1.SetActive (false);
		}
		if (bulletCounter2 == false) 
		{
			bullet2.SetActive (false);
		}
		if (bulletCounter3 == false) 
		{
			bullet3.SetActive (false);
		}

		if (bulletCounter1 == true) 
		{
			bullet1.SetActive (true);
		}
		if (bulletCounter2 == true) 
		{
			bullet2.SetActive (true);
		}
		if (bulletCounter3 == true) 
		{
			bullet3.SetActive (true);
		}
	}
}
