using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//Need to setup a UI display for these.
	public GameObject[] players;
	public int maxPoints = 5;

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
			if(player.GetComponent<CarController>().score >= maxPoints)
			{
				print (player + " wins");
				break;
			}
		}
		
	}
}
