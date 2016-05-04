using UnityEngine;
using System.Collections;

public class NavPointers : MonoBehaviour {
	
	public GameObject cam;

	// Use this for initialization
	void Start () {
		for(var i = GameManager.playerCount; i < 4; i++)
		{
			transform.Find ("P" + (i + 1) + "Ind").gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(var i = 0; i < GameManager.playerCount; i++)
		{
			if(cam && cam.GetComponent<LevelCamera> ().car.gameObject != GameManager.players [i])
			{
				Vector3 screenPos = new Vector3(0,0,0);
				transform.Find ("P" + (i + 1) + "Ind").gameObject.SetActive (true);
				screenPos = cam.GetComponent<Camera>().WorldToScreenPoint(GameManager.players [i].transform.position);
				if (screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height && screenPos.z > 0 && GameManager.players [i].GetComponent<CarController>().health > 0) {
					transform.Find ("P" + (i + 1) + "Ind").transform.position = cam.GetComponent<Camera>().WorldToScreenPoint (GameManager.players [i].transform.position + Vector3.up * 10);
				}
				else transform.Find ("P" + (i + 1) + "Ind").gameObject.SetActive (false);
			}
		}
	}
}
