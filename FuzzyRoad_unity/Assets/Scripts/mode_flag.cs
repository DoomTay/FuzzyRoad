using UnityEngine;
using System.Collections;

public class mode_flag : MonoBehaviour {

	public bool have_flag;

	// Use this for initialization
	void Start () {

		have_flag = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision thecol){
	
		if (thecol.gameObject.name == "flag") {
		
			have_flag = true;
		}
	}
}
