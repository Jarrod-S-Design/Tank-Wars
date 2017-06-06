using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	// Variables
	public static Score instance = null;

	public int scoreToReach = 3;
	public int player1Score = 0;
	public int player2Score = 0;
	// Score text
	public Text p1ScoreText;
	public Text p2ScoreText;
	// Victory text
	public Text victoryText;
	// Victory screen
	public GameObject vScreen;


	private bool p1Wins = false;
	private bool p2Wins = false;
	private bool draw = false;
	public bool gameOver = false;
//	public bool p1Dead = false;
//	public bool p2Dead = false;
//	public bool playerDead = false;

//	void Start()
//	{
//		StartCoroutine (Timer ());
//	}

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
	
	// Update is called once per frame
	void Update () 
	{
//		// Tracks if any players are dead
//		if (p1Dead == true || p2Dead == true)
//		{
//			playerDead = true;	
//		}

		// Tracks if any players reach the winning score/draw
		if ((player1Score + player2Score) == (scoreToReach + scoreToReach)) 
		{
			draw = true;
			gameOver = true;
		}
		if (draw == false) 
		{
			if (player1Score == scoreToReach) {
				p1Wins = true;
				gameOver = true;
			}
			if (player2Score == scoreToReach) {
				p2Wins = true;
				gameOver = true;
			}
		}

		if (gameOver) 
		{
			StartCoroutine (Timer ());
		}

		// Turns off the victory screen UI
		if (gameOver == false)
		{
			vScreen.SetActive (false);
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
	// Makes the game wait a bit before going to the victory screen
	IEnumerator Timer()
	{
		yield return new WaitForSeconds (2); 
		vScreen.SetActive (true);
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
}
