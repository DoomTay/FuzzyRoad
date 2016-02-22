using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Car : MonoBehaviour {

	public WheelCollider[] wheels;
	public WheelCollider[] frontWheels;
	public Camera camera;
	public int playerID = 1;
	public Slider healthBar;
    public GameObject attacker; //Chris: Contains owner
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private Transform respawnPoint;

    public int health = 100;
    int damage = 3;
	public float speed;

	public GameObject projectile;
	public Transform Spawnpoint;

	private const float FIRE_GUN_COOLDOWN = .3f;
	private float fireGunTimer;

	// Use this for initialization
	void Start () {
        //Setting up checks for which attacker. May be wrong about this.
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        player3 = GameObject.FindWithTag("Player3");
        player4 = GameObject.FindWithTag("Player4");
        GetComponent<Rigidbody>().centerOfMass += new Vector3(0, 0, 1.0f);
		respawnPoint = transform;
		//respawnPoint.position = transform.position;
		//respawnPoint.rotation = transform.rotation;
		print (respawnPoint.position + "," + respawnPoint.rotation);
		healthBar.maxValue = health;
		healthBar.value = health;
	}
	
	// Update is called once per frame
	void Update () {
//		print (transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z);
		healthBar.value = health;
		if (!InAir ()) {
			foreach (WheelCollider wheel in wheels) {
				wheel.motorTorque = speed * 100 * Input.GetAxis ("Acceleration_P" + playerID);
				if (OppositeSides (transform.InverseTransformDirection (GetComponent<Rigidbody> ().velocity).z, Input.GetAxis ("Acceleration_P" + playerID))) {
					print ("Braking_P" + playerID);
					wheel.brakeTorque = 10000 * speed;
				} else
					wheel.brakeTorque = 0;
			}

			foreach (WheelCollider frontWheel in frontWheels) {
				frontWheel.steerAngle = 30 * Input.GetAxis ("Steering_P" + playerID);
			}
		} else {
			GetComponent<Rigidbody>().AddTorque(transform.forward * GetComponent<Rigidbody>().mass * Input.GetAxis ("Steering_P" + playerID) * 100);
			GetComponent<Rigidbody>().AddTorque(transform.right * GetComponent<Rigidbody>().mass * Input.GetAxis ("Acceleration_P" + playerID) * 100);
		}

		fireGunTimer -= Time.deltaTime;
		
		if (fireGunTimer <= 0) {
			if (Input.GetButtonDown ("Fire_P" + playerID)) {
				GameObject clone;
				clone = (GameObject)Instantiate (projectile, Spawnpoint.position + transform.forward * 5, projectile.transform.rotation);
				
				clone.GetComponent<Rigidbody>().velocity = Spawnpoint.TransformDirection (Vector3.forward * 80);
				
				fireGunTimer = FIRE_GUN_COOLDOWN;
				
				//Destroy(projectile, 2);
				//Destroy(Bullet_Clone, 2);
			}
		}

		//camera.transform.position -= (camera.transform.position - (transform.position + transform.forward * -5 + transform.up * 2)) * 0.25f;
		//camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, transform.rotation, 0.15f);
	}

    void OnCollisionEnter(Collision _collusion)
    {

    }
	bool OppositeSides(float a, float b)
	{
		return (a > 0 && b < 0) || (a < 0 && b > 0);
	}

	public void Damage(int amount)
	{
        //Getting attacker id
        attacker = GetComponent<Projectile>().owner; //Chris: Get owner ID
		health -= amount;
		if (health < 0) {
			Destroy(gameObject);
            //if the attacker killed apply points.
            if(attacker = player2)
            {
                //award points
                GetComponent<Deathmatch>().awardPoints2();
            }
		}
	}

	bool InAir()
	{
		foreach (WheelCollider wheel in wheels) {
			WheelHit hit;
			if(wheel.GetGroundHit(out hit)) return false;
		}
		return true;
	}
}
