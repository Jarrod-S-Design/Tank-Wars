using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour 
{
	public GameObject scoreObj;
//	public Score score;

	public int damage = 20;
	public int bulletHealth = 4;

	public GameObject gm;

	// Run on initialization
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameController");
//		score = gm.GetComponent<Score>;
	}
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
