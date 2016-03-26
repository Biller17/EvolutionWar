using UnityEngine;
using System.Collections;

public class unitUpgrades : MonoBehaviour {
	string civ;

	// Use this for initialization
	void Start () {
		civ = "egypt";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void changeVariables(string unitType, float hp, float atk, float atk_range, float view_range, float def_melee,
	  float def_range, float def_cavalry, float vel_walk, float vel_atk, bool mult) {
		civilizationVariables civilization = GameObject.Find("civilizationVariableController." + civ).GetComponent<civilizationVariables>();

		civilization.changeVariables(unitType, atk, atk_range, view_range, def_melee, def_range, def_cavalry, vel_walk, vel_atk, mult);

		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.name.Contains (unitType)){
				unitVariables variables = go.GetComponent<unitVariables>();
				if(mult){
					variables.hp *= hp; 
				}
				else{
					variables.hp += hp;
				}
			}
		}
	}

	void setVariables(string unitType, float hp, float atk, float atk_range, float view_range, float def_melee,
					float def_range, float def_cavalry, float vel_walk, float vel_atk,
	                  	 float gold_cost, float food_cost, float mat_cost, float mant_food, float mant_mat) {

		civilizationVariables civilization = GameObject.Find("civilizationVariableController." + civ).GetComponent<civilizationVariables>();

		civilization.assignVariables (unitType, atk, atk_range, view_range, def_melee, def_range, def_cavalry, vel_walk, vel_atk, gold_cost, food_cost, mat_cost, mant_food, mant_mat);

		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.name.Contains (unitType)){
				unitVariables variables = go.GetComponent<unitVariables>();
				variables.hp = hp;
			}
		}
	}

	// CLASSIC UPGRADES
	void unlockMelee(){
	}

	void goldenShield(){
		changeVariables ("melee", 1.20f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, true);
	}

	void corinthianHelmet(){
		changeVariables ("melee", 0.0f, 0.0f, 0.0f, 0.0f, 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, false);
	}

	void unlockRange(){
	}

	void eagleView(){
		changeVariables ("ranged", 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
	}

	void unlockCavalry(){
	}

	void aresFavor(){
		changeVariables ("melee", 0.0f, 1.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, true);
		changeVariables ("ranged", 0.0f, 1.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, true);
		changeVariables ("cavalry", 0.0f, 1.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, true);
	}

	void hermesFavor(){
		changeVariables ("melee", 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 1.25f, 0.0f, true);
		changeVariables ("ranged", 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 1.25f, 0.0f, true);
		changeVariables ("cavalry", 0.0f, 0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 1.25f, 0.0f, true);	
	}

	// MEDIEVAL UPGRADES
	void medievalUpdate(){
		setVariables ("melee", 20.0f, 5.0f, 3.0f, 7.0f, 1.5f, 1.7f, 1.0f, 1.25f, 1.7f, 20.0f, 4.0f, 0.0f, 5.0f, 0.0f);
		setVariables ("ranged", 10.0f, 2.5f, 6.0f, 15.0f, 1.0f, 1.7f, 1.0f, 3.0f, 2.75f, 20.0f, 4.0f, 10.0f, 5.0f, 0.5f );
		setVariables ("cavalry", 20.0f, 5.0f, 3.0f, 7.0f, 1.5f, 1.7f, 1.0f, 1.25f, 1.7f, 20.0f, 4.0f, 0.0f, 5.0f, 0.0f );
	}
	
	void lightPike(){
		changeVariables ("melee", 0.0f, 0.5f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
	}

	void steelShield(){
		changeVariables ("melee", 0.0f, 0.0f, 0.0f, 0.0f, 0.1f, 0.1f, 0.1f, 0.0f, 0.0f, false);
	}

	void longRangeCrossbow (){
		changeVariables ("ranged", 0.0f, 0.0f, 0.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
	}

	void betterWoodCrossbow (){
		changeVariables ("ranged", 0.0f, 0.0f, 0.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
	}

	void improveHorses (){
		changeVariables ("cavalry", 5.0f, 0.0f, 0.2f, 0.0f, 0.0f, 0.0f, 0.0f, 0.25f, 0.1f, false);
	}

	void castle(){
		changeVariables ("melee", 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
		changeVariables ("ranged", 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
		changeVariables ("cavalry", 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, false);
	}

	


}