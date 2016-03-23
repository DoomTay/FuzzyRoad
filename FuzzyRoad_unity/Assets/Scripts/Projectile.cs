using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float lifeSpan;
	public int damage;
	public GameObject owner;
	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision(GetComponent<Collider>(), owner.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0) Destroy (gameObject);
	}

	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject != owner) {
			if (_collision.gameObject.GetComponent<CarController> ())
				_collision.gameObject.GetComponent<CarController> ().Damage (damage, owner);
			Destroy (gameObject);
		}
	}
}
