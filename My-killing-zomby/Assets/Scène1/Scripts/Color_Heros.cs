using UnityEngine;
using System.Collections;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class Color_Heros : MonoBehaviour {

	public float sped;
	public float maxSpeed = 1f;
	public float tilt;
	public Boundary boundary;
	
	public GameObject Bullet;
	public Transform BulletSpawn;
	public float fireRate;
	
	private float nextFire;

	public Vector3 speed = new Vector3(30, 0, 30);

	private Vector3 movement;

	// Update is called once per frame
	void FixedUpdate () {
		gameObject.renderer.material.color = Color.blue;
		float inputX = Input.GetAxis("Vertical");
		float inputZ = Input.GetAxis("Horizontal");
		movement = new Vector3(speed.x * inputX, 0, speed.z * -inputZ * Time.deltaTime * 100);

		rigidbody.velocity = movement;
	}


	void Update ()
	{
		Vector3 bulletDirection = Vector3.zero;
		if(Input.GetKeyDown(KeyCode.J)) bulletDirection = Vector3.left;
		else if(Input.GetKeyDown(KeyCode.I)) bulletDirection = Vector3.forward;
		else if(Input.GetKeyDown(KeyCode.L)) bulletDirection = Vector3.right;
		else if(Input.GetKeyDown(KeyCode.K)) bulletDirection = Vector3.back;
		//Debug.Log (bulletDirection);
		bool isFirering = Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.I ) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L);

		if (isFirering && Time.time > nextFire)
		{
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			nextFire = Time.time + fireRate;
			BulletSpawn.rotation = Quaternion.FromToRotation(Vector3.left,bulletDirection);
			//Rigidbody clone;
			Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);// as Rigidbody;
			//clone.velocity = transform.TransformDirection(bulletDirection * 10);
		}
	}
}   




	/*
	void Update ()
	{
		gameObject.renderer.material.color = Color.blue;
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
			//audio.Play ();
		}
	}
	
	void FixedUpdate ()
	{
		gameObject.renderer.material.color = Color.blue;
		float inputX = Input.GetAxis ("Horizontal");
		float inputZ = Input.GetAxis ("Vertical");
		
		movement = new Vector3 (inputX, 0.0f, inputZ);
		rigidbody.velocity = movement;
		
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}	*/

