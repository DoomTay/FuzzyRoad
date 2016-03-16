using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class car_shooting : MonoBehaviour {

	public int playerID = 1;
	public int health = 100;
	int damage = 3;

    public AudioClip fireSound;
    AudioSource sound;
    public GameObject projectile;
	public Transform Spawnpoint;

	private const float FIRE_GUN_COOLDOWN = .1f;
	private float fireGunTimer;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        fireGunTimer -= Time.deltaTime;
        if (Input.GetButton("Fire" + playerID) && fireGunTimer <= 0)
        {
            GameObject clone;
            clone = (GameObject)Instantiate(projectile, Spawnpoint.position + transform.forward * 5, projectile.transform.rotation);
            clone.GetComponent<Projectile>().owner = gameObject;

            clone.GetComponent<Rigidbody>().velocity = Spawnpoint.TransformDirection(Vector3.forward * 80);

            fireGunTimer = FIRE_GUN_COOLDOWN;

            print("firing");

            //Destroy(projectile, 2);
            //Destroy(Bullet_Clone, 2);
        }
        if(Input.GetButton("Fire" + playerID) && !sound.isPlaying){
            sound.Play();

        }
        else if (Input.GetButtonUp("Fire" + playerID))
            sound.Stop();
		}
	
	}

