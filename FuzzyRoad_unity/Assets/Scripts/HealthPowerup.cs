using UnityEngine;
using System.Collections;


public class HealthPowerup : Powerup {
	public int amount;

	public override void ActivatePowerup(GameObject activator)
	{
		activator.GetComponent<CarController> ().health += amount;
	}
}
