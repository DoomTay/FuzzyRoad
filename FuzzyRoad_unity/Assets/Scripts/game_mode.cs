using UnityEngine;
using System.Collections;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script

public class game_mode : MonoBehaviour {

	public Canvas Menu;
	public Button DeathmatchText;
	public Button CTFText;

	// Use this for initialization
	void Start () {

		Menu = Menu.GetComponent<Canvas>();
		DeathmatchText = DeathmatchText.GetComponent<Button> ();
		CTFText = CTFText.GetComponent<Button> ();
		Menu.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void Deathmatch(){

		Application.LoadLevel ("CarPrototype");
	}

	public void CTF(){
	

	}
}
