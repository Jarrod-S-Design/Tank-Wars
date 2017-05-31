using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Tank : MonoBehaviour 
{
	// Variables
	public GameObject tankMain;
	public GameObject particleSys;
	// Health
	public int health = 20;

	public void TakeDamage(int damageToTake)
	{
		health = health - damageToTake;
	}

	// Run on initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (health <= 0)  
		{
			Destroy (this.gameObject);
			particleSys.SetActive (true);
			return;
		}
	}
}
