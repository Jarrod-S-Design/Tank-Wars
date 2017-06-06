using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy : MonoBehaviour 
{
	// Variables
	public static Dont_Destroy instance = null;

	// Don't destroy this object between scenes
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
