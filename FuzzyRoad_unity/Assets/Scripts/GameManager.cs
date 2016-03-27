using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//Need to setup a UI display for these.
	public GameObject[] players;
	public int maxPoints = 5;
	public GameObject[] carSet;
	public GameObject camera;

	private Vector2[] cameraDimensions = {new Vector2(0,0.5f),new Vector2(0.5f,0.5f),new Vector2(0,0),new Vector2(0.5f,0)};

	bool gameEnded = false;

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

		if (true)
			SpawnCars ();
	}
	
	// Update is called once per frame
	void Update () {
		//check when player reaches or exceeds maxPoints.
		foreach(GameObject player in players)
		{
			if(!player) break;
			if(player.GetComponent<CarController>().score >= maxPoints && gameEnded == false)
			{
				StartCoroutine("Winner", player);
				break;
			}
		}
		
	}

	public void BeginGame () {
		StartCoroutine ("BeginMatch");
	}

	public IEnumerator BeginMatch () {
		Application.LoadLevel ("CarPrototype");
		levelLoaded = false;

		while (levelLoaded == false) {
			
			yield return new WaitForEndOfFrame();
			
		}
			SpawnCars ();
		
	}


	IEnumerator Winner (GameObject winner){
		GameObject.Find ("Menu_Controller").GetComponent<ui_timer>().enabled = false;
		GameObject.Find ("Timer").GetComponent<Text> ().text = winner.name + " wins";
		gameEnded = true;
		yield return new WaitForSeconds(5);
		Application.LoadLevel ("Main_Menu2");
	}

	public void SpawnCars()
	{
		for (int i = 0; i < 4; i++) {
			Transform spawnPoint = GameObject.Find ("SpawnPoint" + (i + 1)).transform;
			GameObject newCar = (GameObject)Instantiate (carSet[0], spawnPoint.position, spawnPoint.rotation);
			newCar.name = "Player " + (i + 1);
			newCar.GetComponent<CarController>().playerID = (i + 1);
			newCar.GetComponent<CarController>().healthBar = GameObject.Find ("P" + (i + 1)  +"Health").GetComponent<Slider>();
			newCar.GetComponent<CarController>().scoreDisplay = GameObject.Find ("P" + (i + 1)  +"Score").GetComponent<Text>();
			players[i] = newCar;
			GameObject newCamera = (GameObject)Instantiate (camera, spawnPoint.position, spawnPoint.rotation);
			newCamera.GetComponent<LevelCamera>().car = newCar.transform;
			newCamera.GetComponent<Camera>().rect = new Rect(cameraDimensions[i],new Vector2(0.5f,0.5f));
		}
	}

	void OnLevelWasLoaded(){
		
		levelLoaded = true;
		
	}

}
