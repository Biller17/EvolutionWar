using UnityEngine;
using System.Collections;

public class civilizationVariables : MonoBehaviour {
	public string civ;
	public float melee_atk, ranged_atk, cavalry_atk;
	public float melee_atk_range, melee_view_range, ranged_atk_range, ranged_view_range, cavalry_atk_range, cavalry_view_range;
	public float melee_def_melee, melee_def_ranged, melee_def_cavalry, ranged_def_melee, ranged_def_ranged, ranged_def_cavalry, cavalry_def_melee, cavalry_def_ranged, cavalry_def_cavalry;
	public float melee_vel_walk, melee_vel_atk, ranged_vel_walk, ranged_vel_atk, cavalry_vel_walk, cavalry_vel_atk;
	public float melee_mant_mat, melee_mant_food, ranged_mant_mat, ranged_mant_food, cavalry_mant_mat, cavalry_mant_food;
	public float melee_cost_mat, melee_cost_food, melee_cost_gold, ranged_cost_mat, ranged_cost_food, ranged_cost_gold, cavalry_cost_mat, cavalry_cost_food, cavalry_cost_gold;
	public int materials, food, gold, evolutionCost, habitants, population;
	public float mat_rate, food_rate, gold_rate, evolutionPoints;

	// Use this for initialization
	void Start () {
		// Civilization name
		civ = findCivilizationInName();

		// Unit Ranges
		melee_atk_range = 0f; 
		ranged_atk_range = 0f;
		cavalry_atk_range = 0f;
		melee_view_range = 0f;
		ranged_view_range = 0f;
		cavalry_view_range = 0f;

		// Unit Attacks
		melee_atk = 0f;
		ranged_atk = 0f;
		cavalry_atk = 0f;

		// Unit Defenses
		melee_def_melee = 0f;
		melee_def_ranged = 0f;
		melee_def_cavalry = 0f;
		ranged_def_melee = 0f;
		ranged_def_ranged = 0f;
		ranged_def_cavalry = 0f;
		cavalry_def_melee = 0f;
		cavalry_def_ranged = 0f;
		cavalry_def_cavalry = 0f;

		// Unit Velocities
		melee_vel_walk = 0f;
		melee_vel_atk = 0f;
		ranged_vel_walk = 0f;
		ranged_vel_atk = 0f;
		cavalry_vel_walk = 0f;
		cavalry_vel_atk = 0f;

		// Unit Mantainance
		melee_mant_mat = 0f;
		melee_mant_food = 0f;
		ranged_mant_mat = 0f;
		ranged_mant_food = 0f;
		cavalry_mant_mat = 0f;
		cavalry_mant_food = 0f;

		// Unit Costs
		melee_cost_mat = 0f;
		melee_cost_food = 0f;
		melee_cost_gold = 0f;
		ranged_cost_mat = 0f;
		ranged_cost_food = 0f;
		ranged_cost_gold = 0f;
		cavalry_cost_mat = 0f;
		cavalry_cost_food = 0f;
		cavalry_cost_gold = 0f;

		// Resources
		materials = 0;
		food = 0;
		gold = 0;
		evolutionPoints = 0f;
		evolutionCost = 1;
		habitants = 0;
		population = 0;

		// Rates of production
		mat_rate = 1f;
		food_rate = 1f;
		gold_rate = 1f;
	}

	public void assignVariables(string unitType, float atk, float atk_range, float view_range, float def_melee, float def_ranged, float def_cavalry, float vel_walk, float vel_atk, float gold_cost, float food_cost, float mat_cost, float mant_food, float mant_mat) {
		if (unitType == "melee") {
			melee_atk = atk;
			melee_atk_range = atk_range; 
			melee_view_range = view_range;
			melee_def_melee = def_melee;
			melee_def_ranged = def_ranged;
			melee_def_cavalry = def_cavalry;
			melee_vel_atk = vel_atk;
			melee_vel_walk = vel_walk;
			melee_cost_gold = gold_cost;
			melee_cost_mat = mat_cost;
			melee_cost_food = food_cost;
			melee_mant_food = mant_food;
			melee_mant_mat = mant_mat;

		} else if (unitType == "ranged") {
			ranged_atk = atk;
			ranged_atk_range = atk_range; 
			ranged_view_range = view_range;
			ranged_def_melee = def_melee;
			ranged_def_ranged = def_ranged;
			ranged_def_cavalry = def_cavalry;
			ranged_vel_atk = vel_atk;
			ranged_vel_walk = vel_walk;
			ranged_cost_gold = gold_cost;
			ranged_cost_mat = mat_cost;
			ranged_cost_food = food_cost;
			ranged_mant_food = mant_food;
			ranged_mant_mat = mant_mat;

		} else if (unitType == "cavalry") {
			cavalry_atk = atk;
			cavalry_atk_range = atk_range; 
			cavalry_view_range = view_range;
			cavalry_def_melee = def_melee;
			cavalry_def_ranged = def_ranged;
			cavalry_def_cavalry = def_cavalry;
			cavalry_vel_atk = vel_atk;
			cavalry_vel_walk = vel_walk;
			cavalry_cost_gold = gold_cost;
			cavalry_cost_mat = mat_cost;
			cavalry_cost_food = food_cost;
			cavalry_mant_food = mant_food;
			cavalry_mant_mat = mant_mat;
		}
	}

	public void changeVariables(string unitType, float atk, float atk_range, float view_range, float def_melee, float def_ranged, float def_cavalry, float vel_walk, float vel_atk, bool mult) {
		if (unitType == "melee" && !mult) {
			melee_atk += atk;
			melee_atk_range += atk_range; 
			melee_view_range += view_range;
			melee_def_melee += def_melee;
			melee_def_ranged += def_ranged;
			melee_def_cavalry += def_cavalry;
			melee_vel_atk += vel_atk;
			melee_vel_walk += vel_walk;

		} else if (unitType == "ranged" && !mult) {
			ranged_atk += atk;
			ranged_atk_range += atk_range; 
			ranged_view_range += view_range;
			ranged_def_melee += def_melee;
			ranged_def_ranged += def_ranged;
			ranged_def_cavalry += def_cavalry;
			ranged_vel_atk += vel_atk;
			ranged_vel_walk += vel_walk;

		} else if (unitType == "cavalry" && !mult) {
			cavalry_atk += atk;
			cavalry_atk_range += atk_range; 
			cavalry_view_range += view_range;
			cavalry_def_melee += def_melee;
			cavalry_def_ranged += def_ranged;
			cavalry_def_cavalry += def_cavalry;
			cavalry_vel_atk += vel_atk;
			cavalry_vel_walk += vel_walk;
			
		} else if (unitType == "melee" && mult) {
			melee_atk *= atk;
			melee_atk_range *= atk_range; 
			melee_view_range *= view_range;
			melee_def_melee *= def_melee;
			melee_def_ranged *= def_ranged;
			melee_def_cavalry *= def_cavalry;
			melee_vel_atk *= vel_atk;
			melee_vel_walk *= vel_walk;

		} else if (unitType == "ranged" && mult) {
			ranged_atk *= atk;
			ranged_atk_range *= atk_range; 
			ranged_view_range *= view_range;
			ranged_def_melee *= def_melee;
			ranged_def_ranged *= def_ranged;
			ranged_def_cavalry *= def_cavalry;
			ranged_vel_atk *= vel_atk;
			ranged_vel_walk *= vel_walk;

		} else if (unitType == "cavalry" && mult) {
			cavalry_atk *= atk;
			cavalry_atk_range *= atk_range; 
			cavalry_view_range *= view_range;
			cavalry_def_melee *= def_melee;
			cavalry_def_ranged *= def_ranged;
			cavalry_def_cavalry *= def_cavalry;
			cavalry_vel_atk *= vel_atk;
			cavalry_vel_walk *= vel_walk;
		}
	}

	// From any name, find a part of the name (each part is separated by a comma).
	// for the name "unit.ranged.egypt.medieval.1" and part = 3, "egypt" would return. part = 5, "1" would return.
	string findCivilizationInName () {
		name = GetComponent<Transform> ().name;
		int len = name.Length;
		int namePart = 1;
		int partLeft = 0; // The left-most position of the current part in the sequence.
		int partLen = 0; // The current calculated length of the part in the sequence.
		for (int i = 0; i < len; i++) {
			if (name [i] == '.') {
				namePart += 1;
				// If the next part is detected or the end of the name is reached, the for loop stops.
				if (namePart == 3 || i == len - 1) {
					break;
				}
				partLen = 0;
				partLeft = i + 1; 
			} else {
				partLen += 1;
			}
		}
		// Returns the substring of name starting at the left-most position of the part and spanning a length of the part.
		// (Returns a string with the desired part of the name).
		return name.Substring (partLeft, partLen);
	}
}
