using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
		// Destroy the rocket after 3 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 3);
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "ennemy") {
			Destroy(gameObject);
			//Destroy(col.gameObject);
		Enemy ennemy = col.gameObject.GetComponent<Enemy>() as Enemy;
		if(ennemy != null)
		{
			ennemy.kill();
		}
		} else if (col.gameObject.tag == "terrain") {
			Destroy(gameObject);
		}
	}
}
