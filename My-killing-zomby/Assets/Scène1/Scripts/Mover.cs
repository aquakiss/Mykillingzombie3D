using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;

	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Ennemis") {
			print ("collision avec player, je le tue");
			//rigidbody2D.velocity = movements;
		} else if (col.gameObject.tag == "Décor") {
			print ("j'ai toucher un mur, je bouge");
			//this.gameObject.transform.rotation;
		}
	}
}
