using UnityEngine;
using System.Collections;

public class AntiRollBar : MonoBehaviour {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public float antiRoll = 5000.0f;

	// Update is called once per frame
	void FixedUpdate () {
		WheelHit hit;
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool groundedL = leftWheel.GetGroundHit(out hit);
		if (groundedL)
			travelL = (-leftWheel.transform.InverseTransformPoint(hit.point).y - leftWheel.radius) / leftWheel.suspensionDistance;

		bool groundedR = rightWheel.GetGroundHit(out hit);
		if (groundedR)
			travelR = (-rightWheel.transform.InverseTransformPoint(hit.point).y - rightWheel.radius) / rightWheel.suspensionDistance;

		float antiRollForce = (travelL - travelR) * antiRoll;

		if (groundedL)
			GetComponent<Rigidbody>().AddForceAtPosition(leftWheel.transform.up * -antiRollForce, leftWheel.transform.position);
		if (groundedR)
			GetComponent<Rigidbody>().AddForceAtPosition(rightWheel.transform.up * antiRollForce, rightWheel.transform.position);
	}
}