using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Tank_Movement : MonoBehaviour 
{

	/// Variables
	public XboxController controller;
	public int currentClip = 0;

	// Shooting
	public float bulletSpeed = 0;
	public float timeBetweenShots = 0;
	private float shootingTimer;
	public float reloadSpeed = 0;
	private bool reloaded = true;

	// Bullet Spawn
	public Transform bulletSpawnPoint;

	// Game Object
	public GameObject bulletPrefab;
	public GameObject turret;

	// Use this for initialization
	void Start () 
	{
		shootingTimer = Time.time;
		var bullet = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// Movement
		var x = XCI.GetAxis(XboxAxis.LeftStickX, controller) * Time.deltaTime * 150.0f;
    	var z = XCI.GetAxis(XboxAxis.LeftStickY, controller) * Time.deltaTime * 7.0f;
		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);

		// Shooting
		if (XCI.GetButtonDown(XboxButton.RightBumper, controller))
		{
			if (reloaded = true) 
			{
				if (Time.time - shootingTimer > timeBetweenShots) 
				{
					GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
					GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
					shootingTimer = Time.time;
					TankClip ();
				}
			} 
			else if (reloaded = false) 
			{
				reloadSpeed -= Time.deltaTime;
				if (reloadSpeed < 0) 
				{
					currentClip = 3;
					reloaded = true;
				}
			}
		}
	}

	void TankClip ()
	{
		currentClip = currentClip -1;
		if (currentClip == 0) 
		{
			reloaded = false;
		}
	}
}
