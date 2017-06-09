using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Turret_Rotation : MonoBehaviour {

	//Variables
	public XboxController controller;									// Allows the both controllers to be used
	public float rotateSpeed = 0;
//	public Vector3 previousRotationDirection = Vector3.forward;			// Used for aiming [OLD]

	// Update is called once per frame
	void Update () 
	{
		RotatePlayer ();
	}

	// Turret rotation controls
	private void RotatePlayer () 
	{
		// Turret Rotation New
		var x = XCI.GetAxis(XboxAxis.RightStickX, controller) * Time.deltaTime * rotateSpeed;
		transform.Rotate(0, x, 0);
		var x2 = XCI.GetAxis(XboxAxis.LeftStickX, controller) * Time.deltaTime * -110.0f;
		transform.Rotate(0, x2, 0);

	// Turret Rotation [OLD]
//		float rotateAxisX = XCI.GetAxis(XboxAxis.RightStickX, controller);
//		float rotateAxisZ = XCI.GetAxis(XboxAxis.RightStickY, controller);
//		
//		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);
//		// Is the right thumstick being used
//		if (directionVector.magnitude < 0.1) 
//		{
//			directionVector = directionVector.normalized;
//		}
//		previousRotationDirection = directionVector;
//		transform.rotation = Quaternion.LookRotation (directionVector);
	}
}
