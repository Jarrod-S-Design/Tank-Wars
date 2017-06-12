using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	// Variables
	public static Score instance = null;		
	// Score
	public int scoreToReach = 3;				// Number of rounds players need to reach to win9
	[HideInInspector]
	public int player1Score = 0;				// Player one's current score
	[HideInInspector]
	public int player2Score = 0;				// Player two's current score
	// Score text
	public Text p1ScoreText;					// Defines the text object to write player one's score to
	public Text p2ScoreText;					// Defines the text object to write player two's score to
	// Victory text
	public Text victoryText;					// Defines the text object to write the winning player to
	// Victory screen
	public GameObject vScreen;					// Defines the victory screen object to be turned on and off
	// Timer bool
	public float timeToWait;					// Sets the amount of time to wait before performing an action
	private float countdown;						// Used to count up past timeToWait
	private bool countingDown = false;			// Tracks if the timer is currently counting down
	// Victory condition bools
	[HideInInspector]
	public bool p1Wins = false;					// Whether or not player one has won the match
	[HideInInspector]
	public bool p2Wins = false;					// Whether or not player two has won the match
	[HideInInspector]
	public bool draw = false;					// Whether or not the match was a draw 
	[HideInInspector]
	public bool gameOver = false;				// Whether or not the match has ended
//	[HideInInspector]
	public bool dontMove = false;

	// Checks if there is already a game manager in the scene
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
	
	// Update is called once per frame
	void Update () 
	{
		// Tracks if any players reach the winning score/draw
		if ((player1Score + player2Score) == (scoreToReach + scoreToReach)) 
		{
			draw = true;
			gameOver = true;
		}
		if (draw == false) 
		{
			if (player1Score == scoreToReach) 
			{
				p1Wins = true;
				gameOver = true;
			}
			else if (player2Score == scoreToReach) 
			{
				p2Wins = true;
				gameOver = true;
			}
		}
	
		// Turns off the victory screen UI after a the timer passes the current time
		if (gameOver == false)
		{
			countingDown = false;
			vScreen.SetActive (false);
		}
		if (countingDown == false) 
		{
			countdown = Time.time + timeToWait;
		}
		if (gameOver == true) 
		{
			countingDown = true;
			GameTimer ();
		}

		// Writes to the victory screen text
		if (p1Wins) 
		{
			victoryText.text = "Player 1 Wins!".ToString ();
		}
		if (p2Wins) 
		{
			victoryText.text = "Player 2 Wins!".ToString ();
		}
		if (draw) 
		{
			victoryText.text = "Draw!!".ToString ();
		}
	}
	// Adds the player score and writes the new total to the canvas 
	public void Player1Score ()
	{
		player1Score = player1Score + 1;
		p1ScoreText.text = player1Score.ToString ();
	}
	// Adds the player score and writes the new total to the canvas 
	public void Player2Score ()
	{
		player2Score = player2Score + 1;
		p2ScoreText.text = player2Score.ToString ();
	}

	// Makes the game wait a bit before going to the victory screen
	void GameTimer ()
	{
		if (Time.time > countdown) 
		{
			countingDown = false;
			vScreen.SetActive (true);
			dontMove = true;
		}
	}
}
