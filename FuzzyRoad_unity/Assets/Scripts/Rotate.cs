using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = .01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.down * 1.5f);

		if (Input.GetButtonDown ("Fire1")) {
		
			transform.Rotate(0, speed*Time.deltaTime,0);
		}
	
	}
}
