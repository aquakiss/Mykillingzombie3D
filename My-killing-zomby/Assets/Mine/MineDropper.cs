using UnityEngine;
using System.Collections;

public class MineDropper : MonoBehaviour {

	public KeyCode [] keyboardInputToDrop;
	public GameObject prefabMine;
	public float minTimeBetween=2f;
	public float whenLastMineDrop;


	// Update is called once per frame
	void Update () {
		if (prefabMine != null) {
				bool askDropMine = false;
				foreach (KeyCode kc in keyboardInputToDrop) {
						if (Input.GetKeyDown (kc))
								askDropMine = true;	
				}

				if (askDropMine) {
						float time = Time.timeSinceLevelLoad;
						if (time - whenLastMineDrop > minTimeBetween) {
								whenLastMineDrop = time;
								DropMine ();
						}
				}
		}
	}
	public void DropMine()
	{
		GameObject.Instantiate (prefabMine, transform.position, transform.rotation);
	}
}
