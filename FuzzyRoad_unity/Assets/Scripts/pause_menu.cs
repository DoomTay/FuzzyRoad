using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class pause_menu : MonoBehaviour {

	public Canvas pauseMenu;
	public Button continueText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		
		pauseMenu.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

				
				Time.timeScale = 0;
				pauseMenu.enabled = true;
			}
		}

	
	public void UnPause(){

		Time.timeScale = 1;
		pauseMenu.enabled = false;

		}

	public void Exit_game(){
	
		Application.Quit();
	}
}


