using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    private controlBinds controls;
    private Transform cam;

	// Use this for initialization
	void Start () {
        controls = GameObject.Find("gameVariableController").GetComponent<controlBinds>();
        cam = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(controls.camFw)) { cam.Translate(cam.up * Time.deltaTime * 5); }
	    if (Input.GetKey(controls.camBw)) { cam.Translate(-cam.up* Time.deltaTime * 5); }
	    if (Input.GetKey(controls.camLf)) { cam.Translate(Vector3.left * Time.deltaTime * 5); }
	    if (Input.GetKey(controls.camRt)) { cam.Translate(Vector3.right * Time.deltaTime * 5); }
    }
}
