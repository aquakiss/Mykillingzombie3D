using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
	
	
	public Transform targetToKill;
	public NavMeshAgent movement;
	
	
	public float refresh=0.5f;
	public float lastRefresh;
	
	
	public void Update()
	{
		float time = Time.timeSinceLevelLoad;
		if (time - lastRefresh > refresh) {
			lastRefresh = time;
			CheckIfInit ();
			if(targetToKill==null){
				targetToKill= GetNewTarget();
			}
			if (targetToKill != null && movement != null) {
				movement.destination = targetToKill.position;
			}
		}
	}
	
	public void CheckIfInit()
	{
		if (movement == null) {
			NavMeshAgent agent = GetComponent<NavMeshAgent>() as NavMeshAgent;
			if(agent!=null) movement=agent;
			else Debug.LogWarning("The enemy has no NavMeshAgent script", this.gameObject);
		}
		
	}
	
	public Transform GetNewTarget()
	{
		GameObject gamoPlayer = GameObject.FindWithTag ("Player") as GameObject;
		if(gamoPlayer==null)
		{
			Debug.LogWarning("Enemy is look for target and is not able to find: Player", this.gameObject);
			return null;
		}
		return gamoPlayer.transform;
	}
}
