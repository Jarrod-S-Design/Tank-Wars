using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class Game_Manager : MonoBehaviour 
{
	// Variables
	public XboxController controller;			// Allows the both controllers to be used
	private Score score;						// Accesses the score sript on this game object
	private bool restart = false;				// Whether or not the game needs to restart
	public bool playerDead = false;				// Whether or not a player is dead

	// Run on initialization
	void Start ()
	{
		score = gameObject.GetComponent<Score> ();
	}
	// Update is called once per frame
	void Update () 
	{
		// Testing restart (to be removed)
//		if (XCI.GetButtonDown (XboxButton.Back,controller)) 
//		{
//			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
//		}

		if (playerDead == true) 
		{
			restart = true;	
		} else 
		{
			restart = false;
		}

		if (restart == true)
		{
			playerDead = false;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

		// If the match is finished then the A and B buttons are active
		// Pressing the A button will reset the game completely starting a new match
		// if you press B the game will exit
		if (score.gameOver == true)
		{
			if (XCI.GetButtonDown (XboxButton.A,controller)) 
			{
				// Reset the score text
				score.player1Score = 0;
				score.player2Score = 0;
				// Resets victory bools 
				score.p1Wins = false;
				score.p2Wins = false;
				// Refresh the score text
				score.p1ScoreText.text = score.player1Score.ToString ();
				score.p2ScoreText.text = score.player2Score.ToString ();
				// Reset the game over bool
				score.gameOver = false;
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
			if (XCI.GetButtonDown (XboxButton.B,controller)) 
			{
				Application.Quit ();
			}
		}	
	}
}
