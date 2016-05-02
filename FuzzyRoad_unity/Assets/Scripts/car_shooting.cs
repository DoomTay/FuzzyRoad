using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CarController))]
public class car_shooting : MonoBehaviour {

	public int damage = 3;

    public AudioClip fireSound;
    AudioSource sound;
    public GameObject projectile;
	public Transform Spawnpoint;

	public float fireRate = .1f;
	private float fireGunTimer;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
		sound.clip = fireSound;
    }
	
	// Update is called once per frame
	void Update () {
		fireGunTimer -= Time.deltaTime;
		if (GetComponent<CarController> ().canControl) {
			if (Input.GetButton ("Fire" + GetComponent<CarController> ().playerID) && fireGunTimer <= 0) {
				GameObject clone;
				clone = (GameObject)Instantiate (projectile, Spawnpoint.position, Spawnpoint.transform.rotation);
				clone.GetComponent<Projectile> ().owner = gameObject;
				clone.GetComponent<Projectile> ().damage = damage;

				clone.GetComponent<Rigidbody> ().velocity = Spawnpoint.TransformDirection (Vector3.forward * 80);

				fireGunTimer = fireRate;
			}
			if (Input.GetButton ("Fire" + GetComponent<CarController> ().playerID) && !sound.isPlaying) {
				sound.Play ();

			} else if (Input.GetButtonUp ("Fire" + GetComponent<CarController> ().playerID))
				sound.Stop ();
		}
	}
	
	}

