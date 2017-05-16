using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour {

	/// Variables

	// Movement
	private float movementSpeed = 0.1f;
	private float rotateSpeed = 5;
	private float turretRotateSpeed = 3;
	// Shooting
	public float bulletSpeed = 0;

	public Transform bulletSpawnPoint;

	public GameObject bulletPrefab;
	public GameObject turret;
	// Controls
	// Tank
	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;
	public KeyCode fireKey = KeyCode.Space;
	/// Turret
	// Keyboard
	private KeyCode rotateTurretLeftKey = KeyCode.Q;
	private KeyCode rotateTurretRightKey = KeyCode.E;

	// Health
	public int health = 1;

	public void TakeDamage(int damageToTake)
		{
			health = health - damageToTake;
		}

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		// Health
		if (health <= 0)  
		{
			Destroy (this.gameObject);
			return;
		}
		/// Movement
		// Gamepad
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 7.0f;

		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);
		// Keyboard
//		if (Input.GetKey (forwardsKey)) 
//		{
//			transform.position += transform.forward * movementSpeed;
//		}
//		else if (Input.GetKey (backwardsKey)) 
//		{
//			transform.position += transform.forward * -movementSpeed;
//		}
//		else if (Input.GetKey (rotateRightKey)) 
//		{
//			transform.Rotate (Vector3.up * rotateSpeed);
//		}
//		else if (Input.GetKey (rotateLeftKey)) 
//		{
//			transform.Rotate (Vector3.up * -rotateSpeed);
//		}

		// Turret Rotation
		//Gamepad

		// Keyboard
		if (Input.GetKey (rotateTurretLeftKey)) 
		{
			turret.transform.Rotate (Vector3.up * turretRotateSpeed);
		}
		if (Input.GetKey (rotateTurretRightKey)) 
		{
			turret.transform.Rotate (Vector3.up * -turretRotateSpeed);
		}

		//Shooting
		if (Input.GetKeyDown (fireKey)) 
		{
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
		}
	}
}
