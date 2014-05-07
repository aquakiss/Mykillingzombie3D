using UnityEngine;
using System.Collections;

[System.Serializable]

public class Color_Heros : MonoBehaviour {

	public float maxSpeed = 1f;

	public Vector3 speed = new Vector3(30, 0, 30);

	private Vector3 movement;

	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = Color.blue;
		float inputX = Input.GetAxis("Vertical");
		float inputZ = Input.GetAxis("Horizontal");
		movement = new Vector3(speed.x * inputX, 0, speed.z * -inputZ * Time.deltaTime * 100);
	}

	void FixedUpdate()
	{
		
		rigidbody.velocity = movement;
	}
}
		
	

