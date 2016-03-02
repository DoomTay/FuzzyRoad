using UnityEngine;
using System.Collections;

public class LevelCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.root.position, transform.right, -transform.eulerAngles.x);

		//transform.RotateAround(transform.root.position, transform.up, transform.eulerAngles.y - (transform.root.eulerAngles.y - transform.eulerAngles.y) * .10f);
		transform.RotateAround(transform.root.position, transform.up, transform.root.eulerAngles.y - transform.eulerAngles.y);
		transform.RotateAround(transform.root.position, transform.forward, -transform.eulerAngles.z);
	}
}
