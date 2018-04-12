using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int BUFFER_SIZE = 100;
    private MyKeyFrame[] keyframes = new MyKeyFrame[BUFFER_SIZE];
    private Rigidbody rigidBody;
    private GameManager gm;

	// Use this for initialization
	void Start ()
    {gm = GameObject.FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gm.bIsRecording)
            Record();
        else
            Playback();
	}

    void Playback()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % BUFFER_SIZE;
        Debug.Log("Reading frame: " + frame);
        transform.position = keyframes[frame].pos;
        transform.rotation = keyframes[frame].rot;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % BUFFER_SIZE;
        Debug.Log("Writing frame: " + frame);
        keyframes[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }
}

/// <summary>
/// Stores information relating to a keyframe for recording and playback purposes.
/// Similar to UnityEngine.KeyFrame
/// </summary>
public struct MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float t, Vector3 p, Quaternion r)
    {
        time = t;
        pos = p;
        rot = r;
    }
}
