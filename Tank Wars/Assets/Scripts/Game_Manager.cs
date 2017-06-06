using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class Game_Manager : MonoBehaviour 
{
	// Variables
	private Score score;

	void Start ()
	{
		score = gameObject.GetComponent<Score> ();
	}
	// Update is called once per frame
	void Update () 
	{
		// Testing restart
		if (XCI.GetButtonDown (XboxButton.Back)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

		if (score.gameOver == true)
		{
			if (XCI.GetButtonDown (XboxButton.A)) 
			{
				// Reset the score text
				score.player1Score = 0;
				score.player2Score = 0;
				// Refresh the score text
				score.p1ScoreText.text = score.player1Score.ToString ();
				score.p2ScoreText.text = score.player2Score.ToString ();
				// Reset the game over bool
				score.gameOver = false;
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}	
	}
	public void NextRound ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
