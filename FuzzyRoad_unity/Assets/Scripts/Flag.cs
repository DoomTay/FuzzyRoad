using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	private Transform initialPlace;

	// Use this for initialization
	void Start () {
		initialPlace = transform;
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
			//GetComponent<Collider> ().enabled = false;
		}
		else if (culprit.name == "Capture Zone" && transform.parent != transform.root) {
			CarController captor = transform.root.gameObject.GetComponent<CarController> ();
			transform.parent = transform.root;
			transform.position = initialPlace.position;
			transform.rotation = initialPlace.rotation;
			captor.hasFlag = false;
			//GetComponent<Collider> ().enabled = true;
		}
	}
}
