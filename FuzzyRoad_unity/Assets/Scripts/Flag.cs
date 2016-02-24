using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<CarController> ()) {
			transform.parent = col.transform;
			col.gameObject.GetComponent<CarController> ().hasFlag = true;
			GetComponent<Collider> ().enabled = false;
		}
	}
}
