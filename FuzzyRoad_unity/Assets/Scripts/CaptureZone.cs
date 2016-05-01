using UnityEngine;
using System.Collections;

public class CaptureZone : MonoBehaviour {

	public GameObject captureFlash;
	public AudioClip captureRiff;
    
	// Use this for initialization
	void Start () {
		captureFlash.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!captureFlash.GetComponent<ParticleSystem>().IsAlive()) captureFlash.SetActive (false);
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
			captureFlash.SetActive (true);
			culprit.GetComponent<AudioSource> ().PlayOneShot (captureRiff);
			flag.transform.parent = null;
			flag.transform.position = flag.GetComponent<Flag>().initialPos;
			flag.transform.rotation = flag.GetComponent<Flag>().initialRot;
			flag.GetComponent<Rigidbody> ().isKinematic = false;
			flag.GetComponent<Collider> ().enabled = true;
		}
	}
}
