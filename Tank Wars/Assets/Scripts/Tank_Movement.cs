using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour 
{

	// Variables
	private float movementSpeed = 0.1f;
	private float rotateSpeed = 5;
	private float turretRotateSpeed = 3;

	public float bulletSpeed = 0;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// Movement
		if (Input.GetKey (forwardsKey)) 
		{
			transform.position += transform.forward * movementSpeed;
		}
		else if (Input.GetKey (backwardsKey)) 
		{
			transform.position += transform.forward * -movementSpeed;
		}
		else if (Input.GetKey (rotateRightKey)) 
		{
			transform.Rotate (Vector3.up * rotateSpeed);
		}
		else if (Input.GetKey (rotateLeftKey)) 
		{
			transform.Rotate (Vector3.up * -rotateSpeed);
		}
	}
}
