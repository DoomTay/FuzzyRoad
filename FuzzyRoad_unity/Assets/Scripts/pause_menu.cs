using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class pause_menu : MonoBehaviour {

	//public Canvas pauseMenu;
	public GameObject continueText;
	public GameObject exitText;

	// Use this for initialization
	void Start () {
		
		continueText.SetActive(false);
		exitText.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

				
				Time.timeScale = 0;
				continueText.SetActive(true);
				exitText.SetActive(true);
				Debug.Log ("should show pause menu");
			}
		}

	
	public void UnPause(){

		Time.timeScale = 1;
		continueText.SetActive(false);
		exitText.SetActive(false);

		}

	public void Exit_game(){
	
		Application.Quit();
	}
}


