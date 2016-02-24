using UnityEngine;
using System.Collections;

public class Deathmatch : MonoBehaviour {
    //Need to setup a UI display for these.
	public GameObject[] players;
    public int maxPoints = 5;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //check when player reaches or exceeds maxPoints.
		foreach(GameObject player in players)
		{
			if(player.GetComponent<Car>().score >= maxPoints)
			{
				break;
			}
		}

	}
}
