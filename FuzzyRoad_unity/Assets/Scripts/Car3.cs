using UnityEngine;
using System.Collections;

public class Car3 : MonoBehaviour {

	public WheelCollider[] wheels;
	public WheelCollider[] frontWheels;
	public Camera camera;

	public int health = 100;
	int damage = 3;
	public float speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//		print (transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z);
		if (!inAir ()) {
			foreach (WheelCollider wheel in wheels) {
				wheel.motorTorque = speed * 100 * Input.GetAxis ("Acceleration_P3");
				if (oppositeSides (transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z, Input.GetAxis ("Acceleration_P3"))) {
					print ("Braking");
					wheel.brakeTorque = 10000 * speed;
				} else
					wheel.brakeTorque = 0;
			}

			foreach (WheelCollider frontWheel in frontWheels) {
				frontWheel.steerAngle = 30 * Input.GetAxis ("Steering_P3");
			}
		} else {
			GetComponent<Rigidbody>().AddTorque(transform.forward * GetComponent<Rigidbody>().mass * Input.GetAxis ("Steering_P3") * 100);
			GetComponent<Rigidbody>().AddTorque(transform.right * GetComponent<Rigidbody>().mass * Input.GetAxis ("Acceleration_P3") * 100);
		}

		//camera.transform.position -= (camera.transform.position - (transform.position + transform.forward * -5 + transform.up * 2)) * 0.25f;
		//camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, transform.rotation, 0.15f);
	}

	void OnCollisionEnter(Collision _collusion)
	{

	}
	bool oppositeSides(float a, float b)
	{
		return Mathf.Sign (a) != Mathf.Sign (b);
	}

	bool inAir()
	{
		foreach (WheelCollider wheel in wheels) {
			WheelHit hit;
			if(wheel.GetGroundHit(out hit)) return false;
		}
		return true;
	}
}
