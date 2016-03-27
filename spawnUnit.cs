using UnityEngine;
using System.Collections;

public class spawnUnit : MonoBehaviour {
	
	private civilizationVariables civVars;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		civVars = GameObject.Find("civilizationVariableController.egypt").GetComponent<civilizationVariables>();
	}

	
	// Update is called once per frame
	void Update () {}


	void spawnMelee()
	{
		switch (civVars.era) {
		case "classic":
			civVars.gold -= 10;
			civVars.food -= 2;
			GameObject meleeC = Instantiate(Resources.Load("unit.egypt.melee.classic.")) as GameObject; 
			Instantiate (meleeC, transform.position = Vector3.zero , Quaternion.identity);
			break;
		case "medieval":
			civVars.gold -= 20;
			civVars.food -= 4;
			GameObject meleeM = Instantiate(Resources.Load("unit.egypt.melee.medieval")) as GameObject; 
			Instantiate (meleeM, transform.position = Vector3.zero , Quaternion.identity);
			break;

		}
	}

	void spawnRange()
	{
		switch (civVars.era) {
		case "classic":
			civVars.gold -= 10;
			civVars.food -= 2;
			civVars.materials -= 4;
			GameObject rangeC = Instantiate (Resources.Load ("unit.egypt.range.classic")) as GameObject; 
			Instantiate (rangeC, transform.position = Vector3.zero, Quaternion.identity);
			break;
		case "medieval":
			civVars.gold -= 20;
			civVars.food -= 4;
			civVars.materials -= 10;
			GameObject rangeM = Instantiate (Resources.Load ("unit.egypt.range.medieval")) as GameObject; 
			Instantiate (rangeM, transform.position = Vector3.zero, Quaternion.identity);
			break;	
		}
	}

	void spawnCavalry()
	{
		switch (civVars.era) {
		case "classic":
			civVars.gold -= 20;
			civVars.food -= 5;
			civVars.materials -= 5;
			GameObject cavalryC = Instantiate (Resources.Load ("unit.egypt.cavalry.classic")) as GameObject; 
			Instantiate (cavalryC, transform.position = Vector3.zero, Quaternion.identity);
			break;
		case "medieval":
			civVars.gold -= 50;
			civVars.food -= 10;
			civVars.materials -= 5;
			GameObject cavalryM = Instantiate (Resources.Load ("unit.egypt.cavalry.medieval")) as GameObject; 
			Instantiate (cavalryM, transform.position = Vector3.zero, Quaternion.identity);
			break;	
		}
	}
}
