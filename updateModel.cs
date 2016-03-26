using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class updateModel : MonoBehaviour {

	List<GameObject> gameObjects;
	public Vector3 pos;

	// Use this for initialization
	void Start () {
		gameObjects = new List<GameObject>();
		changeModel ("unit.melee", "building.pyramid");

	}
	
	// Update is called once per frame
	void Update () {
	}

	void changeModel(string original, string substitute) {
		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.name.Contains (original))
				gameObjects.Add (go);
		}
	
		foreach (GameObject go in gameObjects) {
			pos = go.transform.position;
			Destroy (go);

			GameObject subs = Instantiate(Resources.Load("building.pyramid")) as GameObject; 
			Instantiate (subs, pos, Quaternion.identity);
		}

	}
}
