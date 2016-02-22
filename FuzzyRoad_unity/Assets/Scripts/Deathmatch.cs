using UnityEngine;
using System.Collections;

public class Deathmatch : MonoBehaviour {
    //Need to setup a UI display for these.
    public int player1Points = 0;
    public int player2Points = 0;
    public int player3Points = 0;
    public int player4Points = 0;
    public int maxPoints = 5;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //check when player reaches or exceeds maxPoints.
	    if(player1Points >= maxPoints)
        {

        }
        else if(player2Points >= maxPoints)
        {

        }
        else if(player3Points >= maxPoints)
        {

        }
        else if(player4Points >= maxPoints)
        {

        }

	}

    public void awardPoints1()
    {

    }
    public void awardPoints2()
    {
        player2Points++;
    }
    public void awardPoints3()
    {

    }
    public void awardPoints4()
    {

    }
}
