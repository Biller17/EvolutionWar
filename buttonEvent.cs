using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonEvent : MonoBehaviour {
	public GameObject spawnObject;
	public Button button;

	//Use this for initialization
	void Awake () {
		button = GetComponent<Button> ();

		button.onClick.AddListener (spawn);

		//horse = Instantiate (Resources.Load ("egypt.unit.cavalry.classic")) as GameObject; 
	}

	public void spawn()
	{
		if (button.name.Contains("cavalrySpawn")) {
			spawnObject = Instantiate (Resources.Load ("egypt.unit.cavalry.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}
		if (button.name.Contains("meleeSpawn")) {
			spawnObject = Instantiate (Resources.Load ("egypt.unit.melee.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}
		if (button.name.Contains("rangeSpawn")) {
			spawnObject = Instantiate (Resources.Load ("egypt.unit.ranged.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}
		if (button.name.Contains("houseSpawn")) {
			spawnObject = Instantiate (Resources.Load ("egypt.building.house.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}
		if (button.name.Contains("farmSpawn")) {
			spawnObject = Instantiate (Resources.Load ("egypt.building.farm.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}

		if (button.name.Contains("pyramidSpawn")) 
		{
			spawnObject = Instantiate (Resources.Load ("egypt.building.pyramid.classic"),Camera.main.transform.position, Quaternion.identity) as GameObject;
		}
}
}	 