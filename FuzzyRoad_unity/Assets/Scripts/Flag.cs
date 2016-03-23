using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	public Vector3 initialPos;
	public Quaternion initialRot;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		initialRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		GameObject culprit = col.transform.root.gameObject;
		if (culprit.GetComponent<CarController> () && transform.parent != transform.root) {
			transform.parent = culprit.transform;
			Transform mount = culprit.transform.Find("FlagMount");
			transform.position = mount.position;
			transform.rotation = mount.rotation;
			culprit.GetComponent<CarController> ().hasFlag = true;
			GetComponent<Collider> ().enabled = false;
		}
	}
}
