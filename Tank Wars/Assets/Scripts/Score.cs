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
	// Victory screen
	public GameObject vScreen;

	private bool p1Wins = false;
	private bool p2Wins = false;
	public bool gameOver = false;

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
		// Tracks if any players reach the winning score
		if (player1Score == scoreToReach) 
		{
			p1Wins = true;
			gameOver = true;
		}

		if (player2Score == scoreToReach) 
		{
			p2Wins = true;
			gameOver = true;
		}
		if (gameOver) {
			StartCoroutine (Timer ());
		}
		if (gameOver == false)
		{
			vScreen.SetActive (false);
		}
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (2); 
		vScreen.SetActive (true);
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
}
