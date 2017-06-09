using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour 
{
	// Bullet
	public int damage = 20;						// Bullet damage
	public int bulletHealth = 4;				// Number of times the bullet can bounce before dying -1
	// Game Manager
	public GameObject gm;						// Defines the game manager object

	// Run on initialization
	// Finds the gama manager using its tag
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameController");
	}

	// Checks what the bullet is hitting
	// If its one of the players it destroy's them and updates the score
	// if its a wall the bullet will deduct one from its health
	// if its another bullet the bullet will destroy itself
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player2") 
		{
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player1Score ();
			gm.GetComponent<Game_Manager> ().playerDead = true;		
		} 
		else if (other.tag == "Player1") 
		{
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player2Score ();
			gm.GetComponent<Game_Manager> ().playerDead = true;
		} 
		else if (other.tag == "Wall") 
		{
			bulletHealth = bulletHealth - 1;
			if (bulletHealth < 0)
			Destroy (this.gameObject);
		} 
		else if (other.tag == "Bullet")
		{
			Destroy (this.gameObject);
		}
	}
}
