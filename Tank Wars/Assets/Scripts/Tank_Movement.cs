using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Tank_Movement : MonoBehaviour 
{

	/// Variables
	public XboxController controller;
	public int currentClip = 0;

	// Shooting/Fire rate
	public float bulletSpeed = 0;
	public float timeBetweenShots = 0;
	private float reload;
	public float reloadSpeed = 0;
	private float reloadComplete;
	private float shootingTimer;
	public bool loaded = true;

	// Movement
	public float forwardSpeed = 150.0f;
	public float rotateSpeed = 7.0f;

	// Bullet Spawn
	public Transform bulletSpawnPoint;

	// Game Objects
	public GameObject bulletPrefab;
	public GameObject turret;

	// Run on initialization
	void Start () 
	{
		shootingTimer = Time.time;
		//reload = Time.deltaTime;
		var bullet = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//Timing
		reloadComplete = Time.deltaTime;
		// Movement controls
		var x = XCI.GetAxis(XboxAxis.LeftStickX, controller) * Time.deltaTime * forwardSpeed;
		var z = XCI.GetAxis(XboxAxis.LeftStickY, controller) * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);

		// Shooting
		if (XCI.GetButtonDown(XboxButton.RightBumper, controller))
		{
			if (loaded) 
			{
				Debug.Log ("loaded");
				if (Time.time - shootingTimer > timeBetweenShots) 
				{
					FireBullet ();
					TankClip ();
				}
			} 
			else //if (reloaded = false) 
			{
				Debug.Log ("not loaded");
//				reload = Time.deltaTime + reloadSpeed;
//				if (reload < Time.time) 
//				{
//					currentClip = 3;
//					loaded = true;
//					Debug.Log ("reload working");
//				}
			}
		}
	//	Debug.Log (reloadComplete);
	
//		if (reload < Time.time) 
//		{
//			reload = Time.time + reloadSpeed;
//			currentClip = 3;
//			loaded = true;
//			Debug.Log ("reload working");
//		}
	
	}

	// Handles clip size for tanks
	void TankClip ()
	{
		currentClip = currentClip -1;
		if (currentClip <= 0) 
		{
			reload = Time.time + reloadSpeed;
			loaded = false;
			Debug.Log ("currentClip working");
		}
	}

	// Fires a bullet from the player's position forward
	void FireBullet ()
	{
		GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
		GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
		shootingTimer = Time.time;
	}
}
