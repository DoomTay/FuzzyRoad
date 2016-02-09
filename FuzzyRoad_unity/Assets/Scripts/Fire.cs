using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    public static bool shot_enemy;

    // Use this for initialization
    void Start () {
        shot_enemy = false;

    }

    // Update is called once per frame
    void Update()
    {
        var forward = transform.TransformDirection(Vector3.forward);
        //note the use of var as the type. This is because in c# you
        // can have lamda functions which open up the use of untyped variables
        //these variables can only live INSIDE a function.
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward * 8, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit, 200))
        {

            Debug.Log("HIT");
            if (Input.GetButtonDown("Fire1"))
            {
                print("Shot fired");
            }

            if (Input.GetButtonDown("Fire1") && hit.collider.gameObject.name == "Enemy")
            {
                print("Enemy should be killed");                //shot enemy variable is passed to the enemy class, killing the enemy.
                shot_enemy = true;

            }
        }
    }
}
