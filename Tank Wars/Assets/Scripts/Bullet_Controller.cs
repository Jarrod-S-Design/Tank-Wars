using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour 
{
	public int damage = 1;

	// Use this for initialization
	void Start ()
	{
		Destroy (this.gameObject, 3f);		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<Tank_Movement>
			().TakeDamage (damage);
		}
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
