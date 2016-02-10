using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_timer : MonoBehaviour {
	public Text timerLabel;

	private float time;

	private float minutes;
	private float seconds;
	private float fraction;


	void Update() {
		time += Time.deltaTime;

		minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		seconds = time % 60;//Use the euclidean division for the seconds.
		fraction = (time * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);

		if (minutes >= 1) {
		
			Application.LoadLevel (0);
			Debug.Log ("Timer has ended");
		}
	}
}