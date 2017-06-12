using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Tank_Movement : MonoBehaviour 
{

	/// Variables
	public XboxController controller;					// Allows the both controllers to be used
	// Movement
	public float forwardSpeed = 150.0f;					// How fast the tanks move forward
	public float rotateSpeed = 7.0f;					// How fast the turrets can rotate
	// Shooting/Fire rate
	public float bulletSpeed = 0;						// How fast the bullets move
	public float timeBetweenShots = 0;					// Time between each individual shot
	public int currentClip = 0;							// How many bullets are left in the clip
	public float reloadSpeed = 0;						// How long it takes to refresh the clip
	// Reload timer
	private float reload;								// When this value is more than reloadSpeed refresh the clip
	private float shootingTimer;						// When this value is more than timeBetweenShots you can shoot again
	private bool loaded = true;							// Whether or not the clip has bullets in it
	// Bullet Spawn
	public Transform bulletSpawnPoint;					// Tells the tank where to shoot from
	// Game Objects
	public GameObject bulletPrefab;						// Tells the tank what to shoot
	public GameObject turret;							// Defines the turret game object for this script to use
	[HideInInspector]
	public GameObject gM;								// Defines the game manager game object for this script to use
	public bool canMove = true;							// Whether or not this player can move

	// Run on initialization
	void Start () 
	{
		gM = GameObject.FindGameObjectWithTag("GameController");
		shootingTimer = Time.time;
	}

	// Update is called once per frame
	void Update () 
	{
		if ((gM.GetComponent<Score> ().dontMove) == false) 
		{
			if (canMove == true) 
			{
				// Movement controls
				var x = XCI.GetAxis (XboxAxis.LeftStickX, controller) * Time.deltaTime * forwardSpeed;
				var z = XCI.GetAxis (XboxAxis.LeftStickY, controller) * Time.deltaTime * rotateSpeed;
				transform.Rotate (0, x, 0);
				transform.Translate (0, 0, z);

				// Shooting
				// Variable allowing the if statement to convert to a bool
				var trigger = XCI.GetAxis (XboxAxis.RightTrigger, controller);

				if (loaded) 
				{
					reload = Time.time;
					//[Old Code]if (XCI.GetButtonDown (XboxButton.RightBumper, controller)) 
					if (trigger >= 0.3f) 
					{
						if (Time.time - shootingTimer > timeBetweenShots) 
						{
							FireBullet ();
							TankClip ();
						}
					}
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
