using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class Game_Manager : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		// Testing
		if (XCI.GetButtonDown (XboxButton.Back)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
