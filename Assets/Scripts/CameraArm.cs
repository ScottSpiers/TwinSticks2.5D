using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    private GameObject player;
    private Vector3 armRot;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRot = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        armRot.x += (Input.GetAxis("RVertical") * rotationSpeed);
        armRot.y += (Input.GetAxis("RHorizontal") * rotationSpeed);

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRot);
	}
}
