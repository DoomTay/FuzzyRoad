﻿using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

   
    public Transform car;



    public Vector3 Offset = new Vector3(0f,3.5f,-9f);
    // Use this for initialization
    void Start()
    {
		this.transform.position = car.position + transform.TransformDirection (Offset);
		var flatVectorToTarget = car.forward;
		flatVectorToTarget.y = 0;
		var newRotation = Quaternion.LookRotation(flatVectorToTarget);
		transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
		this.transform.position = car.position + transform.TransformDirection (Offset);

		var flatVectorToTarget = car.forward;
		flatVectorToTarget.y = 0;
		var newRotation = Quaternion.LookRotation(flatVectorToTarget);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.05f);
    }
}