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
	private GameObject p1;						// Defines player 1's tank treads
	private GameObject p2;						// Defines player 2's tank treads
	public GameObject wallPuff;					// Defines the particle system for bouncing off of walls
	public GameObject explosion;				// Defines the particle system for death explosions
	public GameObject bulletTrail;				// Defines the prefab for the bullet kill trail
	public bool trailActive = false;			// Whether or not the bullet has a trail following it

	// Run on initialization
	// Finds the gama manager using its tag
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag ("GameController");
		p1 = GameObject.FindGameObjectWithTag ("P1 Main");
		p2 = GameObject.FindGameObjectWithTag ("P2 Main");
		Instantiate (bulletTrail, this.gameObject.transform.position,Quaternion.identity);
		trailActive = true;
	}

	// Checks what the bullet is hitting
	// If its one of the players it destroy's them and updates the score
	// if its a wall the bullet will deduct one from its health
	// if its another bullet the bullet will destroy itself
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player2") 
		{
			Instantiate (explosion, this.gameObject.transform.position,Quaternion.identity);
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player1Score ();
			gm.GetComponent<Game_Manager> ().playerDead = true;	
			p2.GetComponent<Tank_Movement> ().canMove = false;
		} 
		else if (other.tag == "Player1") 
		{
			Instantiate (explosion, this.gameObject.transform.position,Quaternion.identity);
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player2Score ();
			gm.GetComponent<Game_Manager> ().playerDead = true;
			p1.GetComponent<Tank_Movement> ().canMove = false;
		} 
		else if (other.tag == "Wall") 
		{
			Instantiate (wallPuff, this.gameObject.transform.position,Quaternion.identity);
			bulletHealth = bulletHealth - 1;
			if (bulletHealth < 0)
			Destroy (this.gameObject);
		} 
		else if (other.tag == "Bullet")
		{
			Instantiate (wallPuff, this.gameObject.transform.position,Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
