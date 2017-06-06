using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour 
{
	public int damage = 20;
	public int bulletHealth = 4;

	public GameObject gm;

	// Run on initialization
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameController");
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player2") 
		{
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player1Score ();
		} 
		else if (other.tag == "Player1") 
		{
			other.GetComponent<Destroy_Tank> ().TakeDamage (damage);
			Destroy (this.gameObject);
			gm.GetComponent<Score> ().Player2Score ();
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
