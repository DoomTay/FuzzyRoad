using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//Need to setup a UI display for these.
	public GameObject[] players;
	public int maxPoints = 5;

	bool gameEnded = false;

	public enum gamemode{Deathmatch, CTF};

	public gamemode currentGamemode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//check when player reaches or exceeds maxPoints.
		foreach(GameObject player in players)
		{
			if(player.GetComponent<CarController>().score >= maxPoints && gameEnded == false)
			{
				StartCoroutine("Winner", player);
				break;
			}
		}
		
	}

	IEnumerator Winner (GameObject winner){
		GameObject.Find ("Menu_Controller").GetComponent<ui_timer>().enabled = false;
		GameObject.Find ("Timer").GetComponent<Text> ().text = winner.name + " wins";
		gameEnded = true;
		yield return new WaitForSeconds(5);
		Application.LoadLevel ("Main_Menu2");
	}

}
