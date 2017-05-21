using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Tank : MonoBehaviour 
{
	public GameObject tankMain;
	// Health
	public int health = 20;

	public void TakeDamage(int damageToTake)
	{
		health = health - damageToTake;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (health <= 0)  
		{
			Destroy (this.gameObject);
			return;
		}
	}
}
