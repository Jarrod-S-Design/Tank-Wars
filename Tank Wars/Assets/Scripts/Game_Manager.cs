using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class Game_Manager : MonoBehaviour 
{
	// Variables
	private Score score;
	private GameObject p1;
	private bool restart = false;
	public bool playerDead = false;
	void Start ()
	{
		score = gameObject.GetComponent<Score> ();
//		playerDead = p1.GetComponent<Destroy_Tank> ().playerDead;
	}
	// Update is called once per frame
	void Update () 
	{
//		p1 = GameObject.FindGameObjectWithTag("Player1");
//		playerDead = p1.GetComponent<Destroy_Tank> ().playerDead;

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
			if (XCI.GetButtonDown (XboxButton.B)) 
			{
				Application.Quit ();
			}
		}	
	}
	public void NextRound ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
