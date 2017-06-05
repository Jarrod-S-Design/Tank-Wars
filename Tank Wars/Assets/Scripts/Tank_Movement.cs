using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Tank_Movement : MonoBehaviour 
{

	/// Variables
	public XboxController controller;

	// Movement
	public float forwardSpeed = 150.0f;
	public float rotateSpeed = 7.0f;

	// Shooting/Fire rate
	public float bulletSpeed = 0;
	public float timeBetweenShots = 0;
	public int currentClip = 0;
	public float reloadSpeed = 0;

	private float reload;
	private float shootingTimer;
	private bool loaded = true;

	// Bullet Spawn
	public Transform bulletSpawnPoint;

	// Game Objects
	public GameObject bulletPrefab;
	public GameObject turret;

	// Bullet Counter
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;

	// Run on initialization
	void Start () 
	{
		shootingTimer = Time.time;
		var bullet = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// Movement controls
		var x = XCI.GetAxis(XboxAxis.LeftStickX, controller) * Time.deltaTime * forwardSpeed;
		var z = XCI.GetAxis(XboxAxis.LeftStickY, controller) * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);

		// Shooting
		// Variable allowing the if statement to convert to a bool
		var trigger = XCI.GetAxis (XboxAxis.RightTrigger, controller);

		if (loaded) 
		{
			reload = Time.time;
//			if (XCI.GetButtonDown (XboxButton.RightBumper, controller)) 
			if (trigger >= 0.3f)
			{
				if (Time.time - shootingTimer > timeBetweenShots) 
				{
					FireBullet ();
					TankClip ();
				}
			}
		}
		Reload ();
	}

	// Handles clip size and bullet deduction for tanks
	void TankClip ()
	{
		currentClip = currentClip -1;
		if (currentClip <= 0) 
		{
			loaded = false;
		}

		if (!loaded) 
		{
			reload = Time.time + reloadSpeed;
		}
	}

	// Fires a bullet from the player's position forward
	void FireBullet ()
	{
		GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
		GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
		shootingTimer = Time.time;
	}

	// Sets the reload timer ahead of game time and reloads once time catches up
	void Reload ()
	{
		if (Time.time > reload)
		{
			currentClip = 3;
			loaded = true;
		}
	}
}
