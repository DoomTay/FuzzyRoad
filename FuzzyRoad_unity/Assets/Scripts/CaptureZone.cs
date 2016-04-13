using UnityEngine;
using System.Collections;

public class CaptureZone : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		GameObject culprit = col.transform.root.gameObject;
		if (culprit.GetComponent<CarController>() && culprit.GetComponent<CarController>().hasFlag == true) {
			CarController captor = culprit.GetComponent<CarController> ();
			GameObject flag = culprit.transform.Find("Flag").gameObject;
			captor.hasFlag = false;
            captor.flagCapture++;
			captor.score += 3;
			flag.transform.parent = null;
			flag.transform.position = flag.GetComponent<Flag>().initialPos;
			flag.transform.rotation = flag.GetComponent<Flag>().initialRot;
			flag.GetComponent<Collider> ().enabled = true;
		}
	}
}
