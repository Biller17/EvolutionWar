using UnityEngine;
using System.Collections;

public class buttonSpawn : MonoBehaviour {
	public GameObject spawnButton;
	public Vector2 uiPos;

	// Use this for initialization
	void Start () {
		//spawnButton = Instantiate(prefab) as GameObject;
		//spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		//horseSpawnButton.transform.position = new Vector2 (88, -

		//if(menu.id == "Units")
		spawnButton = Instantiate(Resources.Load("cavalrySpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		uiPos = spawnButton.transform.position;
		uiPos+= new Vector2(0.0f, -30.0f);

		spawnButton = Instantiate(Resources.Load("meleeSpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		spawnButton.transform.position = uiPos;
		uiPos += new Vector2 (0.0f, -30.0f);

		spawnButton = Instantiate(Resources.Load("rangeSpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		spawnButton.transform.position = uiPos;
		uiPos += new Vector2 (0.0f, -60.0f);

		spawnButton = Instantiate(Resources.Load("houseSpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		spawnButton.transform.position = uiPos;
		uiPos += new Vector2 (0.0f, -30.0f);

		spawnButton = Instantiate(Resources.Load("farmSpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		spawnButton.transform.position = uiPos;
		uiPos += new Vector2 (0.0f, -30.0f);

		spawnButton = Instantiate(Resources.Load("pyramidSpawn")) as GameObject;
		spawnButton.transform.SetParent (GetComponent<Transform> (), false);
		spawnButton.transform.position = uiPos;
		uiPos += new Vector2 (0.0f, -30.0f);

		//

		//Instantiate (pyramidButton, transform.position = Vector3.zero , Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {}
}
