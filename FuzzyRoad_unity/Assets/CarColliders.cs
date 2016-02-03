using UnityEngine;
using System.Collections;

public class CarColliders : MonoBehaviour {

	public WheelCollider[] wheels;
	public WheelCollider[] frontWheels;

	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		print (transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z);
		foreach(WheelCollider wheel in wheels)
		{
			wheel.motorTorque = speed * 100 * Input.GetAxis("Acceleration");
			if(oppositeSides(transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z, Input.GetAxis("Acceleration")))
			{
				print ("Braking");
				wheel.brakeTorque = 10000 * speed;
			}
			else wheel.brakeTorque = 0;
		}

		foreach(WheelCollider frontWheel in frontWheels)
		{
			frontWheel.steerAngle = 40 * Input.GetAxis("Steering");
		}
	}

	bool oppositeSides(float a, float b)
	{
		return (a > 0 && b < 0) || (a < 0 && b > 0);
	}
}
