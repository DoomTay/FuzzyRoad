using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public Rigidbody[] wheels;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Mathf.Approximately(Input.GetAxis ("Acceleration"),0))
		{
			foreach(Rigidbody wheel in wheels)
			{
				wheel.AddTorque(transform.right * 1000 * Input.GetAxis ("Acceleration"));
			}
		}
	}
}
