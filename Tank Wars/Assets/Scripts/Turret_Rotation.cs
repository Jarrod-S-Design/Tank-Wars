using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Turret_Rotation : MonoBehaviour {

	//Variables
	public XboxController controller;
	public Vector3 previousRotationDirection = Vector3.forward;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		RotatePlayer ();
	}

	private void RotatePlayer () 
	{
		float rotateAxisX = XCI.GetAxis(XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis(XboxAxis.RightStickY, controller);

		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);
		// Is the right thumstick being used
		if (directionVector.magnitude < 0.1) 
		{
			directionVector = directionVector.normalized;
		}
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);
	}
}
