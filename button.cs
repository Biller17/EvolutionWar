using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	public GameObject pyramidButton;

	

	// Use this for initialization
	void Start () {
		pyramidButton = Instantiate(Resources.Load("pyramidB")) as GameObject; 
		Instantiate (pyramidButton, transform.position = Vector3.zero , Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
