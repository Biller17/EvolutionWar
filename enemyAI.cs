using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyAI : MonoBehaviour {
	private civilizationVariables enemyCivVars;
	private List<string> populationEvolutionUpgrades;
	private List<string> foodEvolutionUpgrades;
	private List<string> materialEvolutionUpgrades;

	// Use this for initialization
	void Start () {
		enemyCivVars = GameObject.Find ("civilizationVariableController.Egypt").GetComponent<civilizationVariables>();

		populationEvolutionUpgrades.Add ("house");
		populationEvolutionUpgrades.Add ("house2");

		foodEvolutionUpgrades.Add ("agriculture");
		foodEvolutionUpgrades.Add ("temples");
		foodEvolutionUpgrades.Add ("agora");
		foodEvolutionUpgrades.Add ("irrigation");
		foodEvolutionUpgrades.Add ("irrigation2");
		foodEvolutionUpgrades.Add ("church");

		materialEvolutionUpgrades.Add ("forest");
		materialEvolutionUpgrades.Add ("temples");
		materialEvolutionUpgrades.Add ("agora");
		materialEvolutionUpgrades.Add ("mines");
		materialEvolutionUpgrades.Add ("smith");
		materialEvolutionUpgrades.Add ("church");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void nextDay() {
		checkPopulation ();
	}
		
	void populationEvolution() {
		// if population evolution available, research

	}


	void checkPopulation () {
		if ((20 * enemyCivVars.population / 100) > enemyCivVars.idleWorkers) {
			if (!house.unlocked) {
				house.unlock ();
			} else {
				if(house.canLvl()){
					house.upgrade ();
				}
				else {
					if(mat_rate >0){
						removeWorkers(materials);
					}
					else if(food_rate > 0){
						removeWorkers(materials);
					}
					else if(enemyCivVars.population - enemyCivVars.workers > 0){
						removeSoldiers();
					}
				}
			}
		} else {
			checkFood();
		}
	}

	void checkFood() {
		if (enemyCivVars.food_rate < 1.5 * (enemyCivVars.melee_mant_food +
			enemyCivVars.ranged_mant_food + enemyCivVars.cavalry_mant_food)) { 

			if (!agriculture.unlocked) {
				agriculture.unlock (); 
			} else {
				if (agriculture.canLvl ()) {
					agriculture.upgrade ();
				} else {
					// If can be upgraded, upgrade anything of food type
					if (isEvolutionFoodUpgrade ()) {
						upgradeEvolutionFood ();
					} else if (mat_rate > 0) {
						removeWorkers (materials);
					} else if (enemyCivVars.population - enemyCivVars.workers > 0) {
						removeSoldiers ();
					}
				}

			}
		} else {
			checkMilitary();
		}
	}	
}
