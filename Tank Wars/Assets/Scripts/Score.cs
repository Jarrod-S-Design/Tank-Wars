using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	// Variables
	public int scoreToReach = 3;
	public int player1Score = 0;
	public int player2Score = 0;

	public Text p1ScoreText;
	public Text p2ScoreText;

	private bool p1Wins = false;
	private bool p2Wins = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player1Score == scoreToReach) 
		{
			p1Wins = true;
		}

		if (player2Score == scoreToReach) 
		{
			p2Wins = true;
		}
	}

	public void Player1Score ()
	{
		player1Score = player1Score + 1;
		p1ScoreText.text = player1Score.ToString ();
	}

	public void Player2Score ()
	{
		player2Score = player2Score + 1;
		p2ScoreText.text = player2Score.ToString ();
	}
//	text.text = result.ToString();
}
