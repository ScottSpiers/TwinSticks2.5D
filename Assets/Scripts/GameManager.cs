using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool bIsRecording = true;
    private bool bIsPaused;

    private float fixedDeltaTime;

    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        Debug.Log("Awake Called");
    }
    // Use this for initialization
    void Start ()
    {
        PlayerPrefsManager.UnlockLevel(0);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(0));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
        bIsRecording = true;
        bIsPaused = false;
        Debug.Log("Start Called");
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

        if (Input.GetButtonDown("Pause"))
        {
            if (bIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        bIsPaused = true;
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    private void Resume()
    {
        bIsPaused = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    private void OnApplicationPause(bool pause)
    {
        bIsPaused = !bIsPaused;
        if (bIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        Debug.Log("OnAppPause Called");
    }
}
