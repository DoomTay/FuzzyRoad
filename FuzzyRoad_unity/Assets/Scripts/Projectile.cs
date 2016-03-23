using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float lifeSpan;
	public int damage;
	public GameObject owner;
	// Use this for initialization
	void Start () {
		Collider[] ownerColliders = owner.GetComponentsInChildren<Collider>(false);
		foreach (Collider ownerCol in ownerColliders) {
			Physics.IgnoreCollision(GetComponent<Collider>(), ownerCol);
		}
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
