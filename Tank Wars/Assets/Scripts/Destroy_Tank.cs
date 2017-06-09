using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Tank : MonoBehaviour 
{
	// Variables
	public GameObject tankMain;					// Defines the game object for the tank treads the chasis and turret are attached to
	public GameObject particleSys;				// Defines the game object that fire death particle system is attached to 

	// Health
	public int health = 20;						// Tank health

	// Bullet Counter	
	public GameObject bullet1;					// Defines the game object first bullet counter 
	public GameObject bullet2;					// Defines the game object Second bullet counter
	public GameObject bullet3;					// Defines the game object Third bullet counter

	// Accesses the Tank_Movement script to get at currentClip
	private Tank_Movement tankMovementScript;

	public bool bulletCounter1 = true;			// Wether or not the first bullet counter is on/off
	public bool bulletCounter2 = true;			// Wether or not the second bullet counter is on/off
	public bool bulletCounter3 = true;			// Wether or not the third bullet counter is on/off


	public void TakeDamage(int damageToTake)
	{
		health = health - damageToTake;
	}

	// Run on initialization
	// Finds the gama manager using the defined game object
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
		// Keeps track of which bullets should be on/off
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
