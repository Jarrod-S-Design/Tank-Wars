using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy : MonoBehaviour 
{
	// Variables
	public static Dont_Destroy instance = null;

	// Checks if there is already a version of this object in the scene
	// If there is it destroys the new one the scene is trying to make
	void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
		} else if (instance != this) 
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (transform.gameObject);	
	}
}
