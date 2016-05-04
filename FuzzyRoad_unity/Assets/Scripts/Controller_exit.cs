using UnityEngine;
using System.Collections;

public class Controller_exit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "Controller")
        {
            for (var i = 0; i < 4; i++)
            {
                if (Input.GetButtonDown("Fire" + (i + 1)))
                {
                    Application.LoadLevel("Main_menu2");
                }
            }
        }
    }
}

