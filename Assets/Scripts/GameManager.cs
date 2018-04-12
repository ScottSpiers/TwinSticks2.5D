using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool bIsRecording = true;

	// Use this for initialization
	void Start ()
    {
        PlayerPrefsManager.UnlockLevel(0);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(0));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
        bIsRecording = true;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            bIsRecording = false;

        }
        else
        {
            bIsRecording = true;
        }
	}
}
