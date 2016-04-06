using UnityEngine;
using System.Collections;

public class buttonEvent : MonoBehaviour {

	//Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		onMouseEnter ();
	}

	void onMouseEnter()
	{
		Debug.Log ("suck my dick");
		if (Input.GetMouseButtonDown (0)) {
			if (this.gameObject.name == "pyramidButton") {
				GameObject pyramid = Instantiate (Resources.Load ("egypt.building.pyramid.classic")) as GameObject; 
				//Instantiate (pyramid, transform.position = Vector3.zero, Quaternion.identity);
			}
		}
	}
}
