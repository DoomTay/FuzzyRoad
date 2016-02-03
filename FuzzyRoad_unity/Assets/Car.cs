using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public Rigidbody[] wheels;
	public Transform[] frontWheels;

	public float speed;

	// Use this for initialization
	void Start () {
		foreach(Rigidbody wheel in wheels)
		{
			wheel.maxAngularVelocity = Mathf.Infinity;
		}

	}
	
	// Update is called once per frame
	void Update () {
		print (1000 * speed * Input.GetAxis ("Acceleration"));
		foreach(Rigidbody wheel in wheels)
		{
			wheel.AddTorque(transform.right * 1000 * speed * Input.GetAxis ("Acceleration"));
		}

		foreach(Transform frontWheel in frontWheels)
		{
			frontWheel.rotation = (transform.rotation * Quaternion.AngleAxis(Input.GetAxis ("Steering") * 40, Vector3.up));
		}
	}
}
