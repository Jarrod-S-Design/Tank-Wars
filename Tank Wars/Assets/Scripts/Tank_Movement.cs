using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Tank_Movement : MonoBehaviour 
{

	/// Variables
	public XboxController controller;

	// Shooting
	public float bulletSpeed = 0;
	public float timeBetweenShots = 0;
	private float shootingTimer;

	// Bullet Spawn
	public Transform bulletSpawnPoint;

	// Game Object
	public GameObject bulletPrefab;
	public GameObject turret;

	// Controls
	public KeyCode fireKey = KeyCode.Joystick1Button5;

	// Use this for initialization
	void Start () 
	{
		shootingTimer = Time.time;
	}

	// Update is called once per frame
	void Update () 
	{
		// Movement
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 7.0f;

		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);

		// Shooting
		if (Input.GetKeyDown (fireKey))
		{
			{
				GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
			}
		}
	}
}
