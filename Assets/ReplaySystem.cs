using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int BUFFER_SIZE = 1000;
    private MyKeyFrame[] keyframes = new MyKeyFrame[BUFFER_SIZE];
    private Rigidbody rigidBody;
    private GameManager gm;
    private bool recToggle;
    private int startFrame;
    private int totalFrames;
    [SerializeField] private int frameCount;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody>();
        recToggle = !gm.bIsRecording;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gm.bIsRecording)
        {
            Record();
        }
        else
        {
            Playback();
        }
	}

    void Playback()
    {

        if(recToggle != gm.bIsRecording)
        {
            recToggle = gm.bIsRecording;
            rigidBody.isKinematic = true;

            int endFrame = Time.frameCount;
            if((endFrame - startFrame) >= BUFFER_SIZE)
            {
                startFrame = endFrame + 1;
                totalFrames = BUFFER_SIZE;
            }
            else
            {
                totalFrames = endFrame - startFrame;
            }
            frameCount = 0;

        }

        int frame = (startFrame + frameCount) % BUFFER_SIZE;
        Debug.Log("Reading frame: " + frame);
        transform.position = keyframes[frame].pos;
        transform.rotation = keyframes[frame].rot;

        ++frameCount;
        if (frameCount >= totalFrames)
        {
            frameCount = 0;
        }
    }

    void Record()
    {
        if(recToggle != gm.bIsRecording)
        {
            recToggle = gm.bIsRecording;
            rigidBody.isKinematic = false;
            startFrame = Time.frameCount;
        }
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
