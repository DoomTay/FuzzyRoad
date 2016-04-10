﻿using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {
		GameObject culprit = col.transform.root.gameObject;
		if (culprit.GetComponent<CarController> ()) {
			ActivatePowerup (culprit);
			Destroy (gameObject);
		}
	}

	public virtual void ActivatePowerup(GameObject activator)
	{
		print ("This isn't supposed to be used, Jerry!");
	}
}