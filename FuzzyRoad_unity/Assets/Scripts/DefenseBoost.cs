using UnityEngine;
using System.Collections;

public class DefenseBoost : Powerup {

	public override void ActivatePowerup(GameObject activator)
	{
		activator.GetComponent<CarController> ().defenseTimer = 10;
	}
}
