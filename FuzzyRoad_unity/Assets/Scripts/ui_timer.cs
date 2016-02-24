using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_timer : MonoBehaviour {
	public Text timerLabel;

	private float time = 420;

	private float minutes;
	private float seconds;


	void Update() {

		// TIMER FOR GAME 
		time -= Time.deltaTime;

		minutes = Mathf.Floor (time / 60); //Divide the guiTime by sixty to get the minutes.
		seconds = Mathf.Floor(time % 60);//Use the euclidean division for the seconds.

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);

		if (time <= 0) {
		
			Application.LoadLevel (0);
			Debug.Log ("Timer has ended");
		}
	}
}