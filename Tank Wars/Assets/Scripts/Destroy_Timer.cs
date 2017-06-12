using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Timer : MonoBehaviour 
{
	public float timeToDestroy;

	// Update is called once per frame
	void Awake () 
	{
		Destroy (this.gameObject, timeToDestroy);
	}
}
