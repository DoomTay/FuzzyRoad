﻿using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class main_menu : MonoBehaviour 
{
	public Canvas startMenu;
	public Button startText;
	public Button exitText;
    public Button controls;
    public Button exitControls;
	public bool[] ready = new bool[4];
	private bool[] heldDown = new bool[4];

	void Start ()
	{
		if(startMenu) startMenu = startMenu.GetComponent<Canvas>();
		if(startText) startText = startText.GetComponent<Button> ();
		if(exitText) exitText = exitText.GetComponent<Button> ();
		if(controls) controls = controls.GetComponent<Button>();
		if(exitControls) exitControls = exitControls.GetComponent<Button>();
		if(startMenu) startMenu.enabled = true;
		for (var i = 0; i < 4; i++) {
			ready [i] = false;
			heldDown [i] = false;
		}

		for (var k = GameManager.playerCount; k < 4; k++) {
			if(GameObject.Find ("Cam" + k)) GameObject.Find ("Cam" + k).SetActive(false);
		}

	}

	void Update ()
	{
		if (Application.loadedLevelName == "Character_Select") {
			for (var i = 0; i < GameManager.playerCount; i++) {
				if (Input.GetButtonDown ("Fire" + (i + 1))) {
					ready [i] = !ready [i];
					GameObject.Find ("P" + (i + 1) + "Array").GetComponent<Rotate> ().enabled = !ready [i];
				}
				if (Input.GetAxis ("Horizontal" + (i + 1)) > 0 && heldDown [i] == false && !ready [i]) {
					IncrementSelection (i);
					heldDown [i] = true;
				} else if (Input.GetAxis ("Horizontal" + (i + 1)) < 0 && heldDown [i] == false && !ready [i]) {
					DecrementSelection (i);
					heldDown [i] = true;
				}
			else if (Input.GetAxis ("Horizontal" + (i + 1)) == 0) {
					heldDown [i] = false;
				}
			}
			if (everyoneReady ())
				BeginGame ();
		}
	}

	bool everyoneReady()
	{
		for (var i = 0; i < GameManager.playerCount; i++) {
			if (ready [i] == false)
				return false;
		}
		return true;
	}

	public void ExitPress() //this function will be used on our Exit button

	{
		startMenu.enabled = true; //enable the Quit menu when we click the Exit button
		startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;

	}

	public void NoPress() //this function will be used for our "NO" button in our Quit Menu

	{
		startMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;

	}

	public void playerSelect()
	{
		Application.LoadLevel ("PlayerCount");
		GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	public void StartLevel (int count) //this function will be used on our Play button
	{
		Application.LoadLevel ("Character_Select");
		GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		GM.setPlayerCount (count);
		GM.charChoices = new int[] {0,0,0,0};
	}

    public void Controls()
    {
        Application.LoadLevel("Controller");
    }

    public void ExitControls()
    {
        Application.LoadLevel("Main_menu2");
    
    }

	public void IncrementSelection(int index)
	{
		print (Input.GetAxis ("Horizontal" + (index + 1)));
		GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		Transform carDisplay = GameObject.Find ("P" + (index + 1) + "Array").transform;
		if (GM.charChoices [index] == GM.carSet.Length - 1) {
			GM.charChoices[index] = 0;
			carDisplay.position = new Vector3(carDisplay.position.x,carDisplay.position.y + (30 * (GM.carSet.Length - 1)),carDisplay.position.z);
		} else {
			GM.charChoices [index]++;
			carDisplay.position = new Vector3(carDisplay.position.x,carDisplay.position.y - 30,carDisplay.position.z);
		}
	}
	
	public void DecrementSelection(int index)
	{
		GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		Transform carDisplay = GameObject.Find ("P" + (index + 1) + "Array").transform;
		if (GM.charChoices [index] == 0) {
			GM.charChoices[index] = GM.carSet.Length - 1;
			carDisplay.position = new Vector3(carDisplay.position.x,carDisplay.position.y - (30 * (GM.carSet.Length - 1)),carDisplay.position.z);
		} else {
			GM.charChoices [index]--;
			carDisplay.position = new Vector3(carDisplay.position.x,carDisplay.position.y + 30,carDisplay.position.z);
		}
	}

	public void BeginGame () {
		GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		GM.StartCoroutine ("BeginMatch");
	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game

	}

}