using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public void kill()
	{		
		NavMeshAgent agent = GetComponent<NavMeshAgent> () as NavMeshAgent;
		if(agent!=null)
			Destroy (agent);
		Collider shell = GetComponent<Collider> () as Collider;
		if(shell!=null)
			Destroy (shell);
		
		Destroy (gameObject, 2);
	}
}
