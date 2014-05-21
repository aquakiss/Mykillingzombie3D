using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	public GameObject ennemi;
	public Transform m_player;
	public int ennemy;
	public float lastRefresh;
	public float spawnDelay = 15f;
	public int nombreVague = 4;

	// Update is called once per frame
	void Start(){
		spawnen ();
	}



	void Update () {
		float time = Time.timeSinceLevelLoad;
		if (time - lastRefresh > spawnDelay && nombreVague > 0) {
			lastRefresh = time;
			spawnen ();
		}
	}

	public void spawnen(){
		while (ennemy > 0) {
			GameObject en = Instantiate (ennemi, transform.position, transform.rotation) as GameObject;	
			en.gameObject.renderer.material.color = Color.red;
			en.GetComponent<NavMeshAgent> ().destination = m_player.position;
			ennemy = ennemy - 1;
		}
		ennemy = 3;
		nombreVague--;
	}
}

