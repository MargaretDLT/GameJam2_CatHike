using UnityEngine;
using System.Collections;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class Billboard : MonoBehaviour 
{
	private void Start()
	{

	}

	void LateUpdate () 
	{
		transform.LookAt(Camera.main.transform.position, Vector3.up);
	}
}
