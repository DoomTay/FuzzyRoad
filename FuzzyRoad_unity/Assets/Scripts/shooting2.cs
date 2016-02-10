using UnityEngine;
using System.Collections;

public class shooting2 : MonoBehaviour {

	public Rigidbody projectile;
	public Transform Spawnpoint;
	public GameObject Bullet_Clone;

	private const float FIRE_GUN_COOLDOWN = .3f;
	private float fireGunTimer;

	// Use this for initialization
	void Start () {

	}

	void Awake(){

		fireGunTimer = 0;
	}

	// Update is called once per frame
	void Update () {

		fireGunTimer -= Time.deltaTime;

		if(fireGunTimer <= 0){
			if(Input.GetButtonDown("Fire1_P2")){
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

				clone.velocity = Spawnpoint.TransformDirection (Vector3.forward*80);

				fireGunTimer = FIRE_GUN_COOLDOWN;

				//Destroy(projectile, 2);
				//Destroy(Bullet_Clone, 2);
			}
		}
	}
}