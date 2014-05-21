using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject explosionPrefab;
	public float force=10f;
	public string tagKeyWordToActivate = "ennemy";

	public void OnTriggerEnter(Collider col )
	{
		if (col.gameObject.tag.Equals (tagKeyWordToActivate)) {
			Explode();		
			Kill(col.gameObject);
		}
	}

	public void Explode()
	{
//		Debug.Log ("Boum");	
		if(explosionPrefab!=null)
		{
			GameObject gamo =GameObject.Instantiate (explosionPrefab, transform.position, transform.rotation) as GameObject;
			Destroy(gamo,10);
		}
		Destroy(this.gameObject);
	}
	public void Kill(GameObject gamo)
	{

		if(gamo==null)return;

		NavMeshAgent agent = gamo.GetComponent<NavMeshAgent> () as NavMeshAgent;
		if(agent!=null)
			Destroy (agent);
		Collider shell = gamo.GetComponent<Collider> () as Collider;
		if(shell!=null)
			Destroy (shell);

		if (gamo.rigidbody != null)
			gamo.rigidbody.AddExplosionForce (force, transform.position, 2);
		Destroy (gamo, 2);
	}
}
