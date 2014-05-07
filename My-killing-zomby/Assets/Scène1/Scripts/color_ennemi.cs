using UnityEngine;
using System.Collections;

public class color_ennemi : MonoBehaviour {

	public Transform m_player;
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = Color.red;
		GetComponent<NavMeshAgent>().destination = m_player.position;
	}
}