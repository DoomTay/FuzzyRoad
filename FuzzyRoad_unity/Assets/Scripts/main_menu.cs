using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class main_menu : MonoBehaviour 
{
	public Canvas startMenu;
	public Button startText;
	public Button exitText;

	void Start ()

	{
		startMenu = startMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		startMenu.enabled = true;

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

	public void StartLevel () //this function will be used on our Play button

	{
		Application.LoadLevel ("Character_Select"); //this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void IncrementSelection(int index)
	{
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