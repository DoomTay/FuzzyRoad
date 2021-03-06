﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//Need to setup a UI display for these.
	public static GameObject[] players = new GameObject[playerCount];
	public int maxPoints = 50;
    public int score;
	public GameObject[] carSet;
	public GameObject camera;

	private Vector2[] fourPlayerCameraDimensions = {new Vector2(0,0.5f),new Vector2(0.5f,0.5f),new Vector2(0,0),new Vector2(0.5f,0)};
	private Vector2[] twoPlayerCameraDimensions = {new Vector2(0,0.5f),new Vector2(0,0)};

	private GameObject[] hudCorners = new GameObject[4];

	public int[] charChoices = new int[4];

	public static int playerCount = 2;

	bool gameEnded = false;

	private GameObject hud;

	public bool levelLoaded;

	public enum gamemode{Deathmatch, CTF};

	public gamemode currentGamemode;

	public static GameManager Instance;

	void Awake ()
	{

        if (Instance) {
			
			DestroyImmediate (gameObject);
			
		} else {
			
			DontDestroyOnLoad (gameObject);
			Instance = this;
			
		}

		/*if (charChoices.Length == 0 && GameObject.Find ("SpawnPoint1")) {
			//StartCoroutine ("DefaultSpawn");
			//playerCount = 2;
			charChoices = new int[] {0,0,0,0};
			SpawnCars ();
		}*/
	}

	public IEnumerator DefaultSpawn () {
		while (levelLoaded == false) {
			if (charChoices.Length == 0 && !levelLoaded)
				break;
			else if (charChoices.Length > 0)
				StopCoroutine ("DefaultSpawn");
			yield return new WaitForEndOfFrame();

		}
		print("Go");
		charChoices = new int[] {0,0,0,0};
		SpawnCars ();

	}

	// Update is called once per frame
	void Update () {
		//check when player reaches or exceeds maxPoints.
		foreach (GameObject player in players) {
			if (!player)
				break;
			if (player.GetComponent<CarController> ().score >= maxPoints && gameEnded == false) {
				StartCoroutine ("Winner", player);
				break;
			}
		}
	}

	public IEnumerator BeginMatch () {
		Application.LoadLevel ("CarPrototype");
		levelLoaded = false;
		StopCoroutine ("DefaultSpawn");
		while (levelLoaded == false) {
			
			yield return new WaitForEndOfFrame();
			
		}
		SpawnCars ();
		foreach(var player in players)
		{
			player.GetComponent<CarController>().KillOrStartEngine(0);
		}
		GameObject.Find ("Menu_Controller").GetComponent<ui_timer> ().enabled = false;
		GameObject.Find ("Timer").GetComponent<Text> ().text = "3";
		yield return new WaitForSeconds (1);
		GameObject.Find ("Timer").GetComponent<Text> ().text = "2";
		yield return new WaitForSeconds (1);
		GameObject.Find ("Timer").GetComponent<Text> ().text = "1";
		yield return new WaitForSeconds (1);
		GameObject.Find ("Timer").GetComponent<Text> ().text = "GO!";
		foreach(var player in players)
		{
			player.GetComponent<CarController>().KillOrStartEngine(1);
		}
		yield return new WaitForSeconds (1);
		GameObject.Find ("Menu_Controller").GetComponent<ui_timer> ().enabled = true;
		
	}

    public void winState (int[] killSet, int[] deathSet, int[] scoreSet, int[] flagCaptureSet) {
        print (killSet);
		print (deathSet);
		for (int i = 0; i < playerCount; i++) {
            GameObject.Find("k" + (i + 1)).GetComponent<Text>().text = killSet[i].ToString();
			GameObject.Find("d" + (i + 1)).GetComponent<Text>().text = deathSet[i].ToString();
            GameObject.Find("p" + (i + 1)).GetComponent<Text>().text = scoreSet[i].ToString();
            GameObject.Find("f" + (i + 1)).GetComponent<Text>().text = flagCaptureSet[i].ToString();
            double kda;
			if(deathSet[i] == 0)
                kda = killSet[i];
			else
                kda = (double)killSet[i] / (double)deathSet[i];
			GameObject.Find("kda" + (i + 1)).GetComponent<Text>().text = kda.ToString("#.##");
        }
		for (int k = playerCount; k < 4; k++) {
			GameObject.Find ("k" + (k + 1)).SetActive (false);
			GameObject.Find ("d" + (k + 1)).SetActive (false);
			GameObject.Find ("p" + (k + 1)).SetActive (false);
			GameObject.Find ("f" + (k + 1)).SetActive (false);
		}
    }


	IEnumerator TimeOut (){
		GameObject.Find ("Timer").GetComponent<Text> ().text = "Time's up";
		gameEnded = true;
		yield return new WaitForSeconds(5);
		StartCoroutine ("GoToScoreboard");
	}

	IEnumerator GoToScoreboard (){
		int[] kills = new int[playerCount];
		int [] deaths = new int[playerCount];
		int[] score = new int[playerCount];
		int[] flagCap = new int[playerCount];
		for (int i = 0; i < playerCount; i++) {
			kills[i] = players[i].GetComponent<CarController>().kills;
			deaths[i] = players[i].GetComponent<CarController>().deaths;
			score[i] = players[i].GetComponent<CarController>().score;
			flagCap[i] = players[i].GetComponent<CarController>().flagCapture;
		}
		Application.LoadLevel ("Win State");
		levelLoaded = false;

		while (levelLoaded == false) {

			yield return new WaitForEndOfFrame();

		}
		winState(kills, deaths, score, flagCap);
	}


	IEnumerator Winner (GameObject winner){
		GameObject.Find ("Menu_Controller").GetComponent<ui_timer>().enabled = false;
		GameObject.Find ("Timer").GetComponent<Text> ().text = winner.name + " wins";
		gameEnded = true;
		yield return new WaitForSeconds(5);
		StartCoroutine ("GoToScoreboard");
	}

	public void setPlayerCount(int count)
	{
		playerCount = count;
	}

	public void SpawnCars()
	{
		if (GameObject.Find ("2PHud") && GameObject.Find ("4PHud")) {
			if (playerCount == 2) {
				hud = GameObject.Find ("2PHud");
				GameObject.Find ("4PHud").SetActive (false);
				for (int i = 0; i < 2; i++) {
					if (GameObject.Find ("P" + (i + 1) + "Group")) {
						hudCorners [i] = hud.transform.Find ("P" + (i + 1) + "Group").gameObject;
						hudCorners [i].SetActive (false);
					}
				}
			} else {
				hud = GameObject.Find ("4PHud");
				GameObject.Find ("2PHud").SetActive (false);

				for (int i = 0; i < 4; i++) {
					if (GameObject.Find ("P" + (i + 1) + "Group")) {
						hudCorners [i] = hud.transform.Find ("P" + (i + 1) + "Group").gameObject;
						hudCorners [i].SetActive (false);
					}
				}
			}
		}

		players = new GameObject[playerCount];

		for (int i = 0; i < playerCount; i++) {
			Transform spawnPoint = GameObject.Find ("SpawnPoint" + (i + 1)).transform;
			GameObject newCar = (GameObject)Instantiate (carSet[charChoices[i]], spawnPoint.position, spawnPoint.rotation);
			newCar.name = "Player " + (i + 1);
			newCar.GetComponent<CarController>().playerID = (i + 1);
			hudCorners[i].SetActive (true);
			newCar.GetComponent<CarController>().healthBar = GameObject.Find ("P" + (i + 1) + "Health").GetComponent<Slider>();
			newCar.GetComponent<CarController>().scoreDisplay = GameObject.Find ("P" + (i + 1) + "Score").GetComponent<Text>();
			players[i] = newCar;
			GameObject newCamera = (GameObject)Instantiate (camera, spawnPoint.position, spawnPoint.rotation);
			newCamera.GetComponent<LevelCamera>().car = newCar.transform;
			GameObject.Find("P" + (i + 1) + "Mask").GetComponent<NavPointers>().cam = newCamera;
			if (charChoices [i] == 3)
				newCamera.GetComponent<LevelCamera> ().Offset = new Vector3 (0, 12, -13);
			if(playerCount == 2) newCamera.GetComponent<Camera>().rect = new Rect(twoPlayerCameraDimensions[i],new Vector2(1f,0.5f));
			else newCamera.GetComponent<Camera>().rect = new Rect(fourPlayerCameraDimensions[i],new Vector2(0.5f,0.5f));
		}
	}

	void OnLevelWasLoaded(){
		
		levelLoaded = true;
		
	}

}
