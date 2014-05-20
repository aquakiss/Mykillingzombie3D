using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	public GameObject ennemi;
	public Transform m_player;
	public int ennemy;

	// Update is called once per frame
	void Update () {
			while (ennemy > 0) {
					spawnen ();
					ennemy = ennemy - 1;
			}
	}

	public void spawnen(){
		GameObject en = Instantiate (ennemi, transform.position, transform.rotation) as GameObject;	
		en.gameObject.renderer.material.color = Color.red;
		en.GetComponent<NavMeshAgent> ().destination = m_player.position;

	}
}

