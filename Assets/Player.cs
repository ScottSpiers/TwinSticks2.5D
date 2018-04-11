using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("X Axis Input: " + CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("Y Axis Input: " + CrossPlatformInputManager.GetAxis("Vertical"));

        if (CrossPlatformInputManager.GetButton("Fire1"))
            Debug.Log("Fire button pressed");

        if (CrossPlatformInputManager.GetButton("Jump"))
            Debug.Log("Jump button pressed");

        if (CrossPlatformInputManager.GetButton("Crouch"))
            Debug.Log("Crouch button pressed");
	}
}
