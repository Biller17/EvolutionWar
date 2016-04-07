using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class unitAttack : MonoBehaviour {
	private civilizationVariables civVars;
	private unitVariables enemyVars;
	private civilizationVariables enemyCivVars;
	private Transform player;
	private bool attacking;
	private unitMovement move;

	private List<GameObject> enemiesInSight;

	public string playerCiv;
	private string playerType;
	private string enemyCiv;

	private float currentEnemyDefense; // dependiendo si es cavalry, melee o range
	private float atk_range;
	private float vel_atk;
	private float melee_def;
	private float ranged_def;
	private float cavalry_def;

	void Start () {
		player = GetComponent<Transform> ();
		move = GetComponent<unitMovement> ();
		playerCiv = findInSoldierName (player.name, 1);
		playerType = findInSoldierName (player.name, 3);

		civVars = GameObject.Find ("civilizationVariableController." + playerCiv).GetComponent<civilizationVariables>();
		attacking = false;

		enemiesInSight = new List<GameObject> ();
	}

	void OnTriggerEnter (Collider col) {
		enemyCiv = findInSoldierName (col.name, 1);

		if (playerCiv != enemyCiv && col.name.Contains("unit") && !enemiesInSight.Contains(col.gameObject)) {
			enemiesInSight.Add (col.gameObject);
		}
	}

	void OnTriggerExit (Collider col) {
		enemyCiv = findInSoldierName (col.name, 1);

		if (playerCiv != enemyCiv && enemiesInSight.Contains(col.gameObject)) {
			enemiesInSight.Remove (col.gameObject);
		}
	}

	void Update() {
		switch (playerType) {
		case "melee":
			atk_range = civVars.melee_atk_range;
			vel_atk = civVars.melee_vel_atk;
			break;
		case "ranged":
			atk_range = civVars.ranged_atk_range;
			vel_atk = civVars.ranged_vel_atk;
			break;
		case "cavalry":
			atk_range = civVars.cavalry_atk_range;
			vel_atk = civVars.cavalry_vel_atk;
			break;
		}

		// Removes any soldiers from the sight list if they have been killed already.
		List<GameObject> temp = new List<GameObject>();
		foreach (GameObject soldier in enemiesInSight) {
			if (soldier == null)
				temp.Add (soldier);
		}
		foreach (GameObject deadSoldier in temp) {
			enemiesInSight.Remove(deadSoldier);
		}

		if (enemiesInSight.Count > 0) {
			// Only one soldier is targetted at a time, so enemySoldier is the first enemy in the list.
			GameObject enemySol = enemiesInSight [0];
			// Checks to see if the enemy is in attack range. If not, moves the soldier to the enemy position.
			if (Vector3.Distance (enemySol.transform.position, GetComponent<Transform>().position) > atk_range) {
				move.SetPos(enemySol.transform.position);
			} else {
				// If the soldier isn't already attacking
				if (!attacking) {
					// Check to see if the civilization of the soldier is the same as the civilization of the previous soldier
					// This tries to avoid running GameObject.Find which can be very resource costly
					if (enemyCiv != findInSoldierName (enemySol.name, 3)) {
						enemyCiv = findInSoldierName (enemySol.name, 3);
						enemyCivVars = GameObject.Find ("civilizationVariableController." + enemyCiv).GetComponent<civilizationVariables> ();

						switch (playerType) {
						case "melee":
							melee_def = enemyCivVars.melee_def_melee;
							ranged_def = enemyCivVars.ranged_def_melee;
							cavalry_def = enemyCivVars.cavalry_def_melee;
							break;
						case "ranged":
							melee_def = enemyCivVars.melee_def_ranged;
							ranged_def = enemyCivVars.ranged_def_ranged;
							cavalry_def = enemyCivVars.cavalry_def_ranged;
							break;
						case "cavalry":
							melee_def = enemyCivVars.melee_def_cavalry;
							ranged_def = enemyCivVars.ranged_def_cavalry;
							cavalry_def = enemyCivVars.cavalry_def_cavalry;
							break;
						}
					}
					enemyVars = enemySol.GetComponent<unitVariables> ();

					// Sets the current enemy defense variable based on the enemy type (second part of its name)
					switch (findInSoldierName (enemySol.name, 2)) {
					case "melee":
						currentEnemyDefense = melee_def;
						break;
					case "ranged":
						currentEnemyDefense = ranged_def;
						break;
					case "cavalry":
						currentEnemyDefense = cavalry_def;
						break;
					}

					// Start the attack with a delay of vel_atk.
					StartCoroutine (attackPlayer (vel_atk, enemyVars));
				}
			}
		}
	}

	IEnumerator attackPlayer(float delay, unitVariables enemy)
	{
		// attacking variable is used to make sure that there is a delay between attacks
		attacking = true;
		// Depending on the player type, the atk is different.
		switch (playerType) {
		case "melee":
			enemy.hp = enemy.hp + currentEnemyDefense - civVars.melee_atk;
			break;
		case "ranged":
			enemy.hp = enemy.hp + currentEnemyDefense - civVars.ranged_atk;
			break;
		case "cavalry":
			enemy.hp = enemy.hp + currentEnemyDefense - civVars.cavalry_atk;
			break;
		}
		// makes a delay of 'delay' seconds
		yield return new WaitForSeconds (delay);
		attacking = false;
	}

	// From any name, find a part of the name (each part is separated by a comma).
	// for the name "unit.ranged.egypt.medieval.1" and part = 3, "egypt" would return. part = 5, "1" would return.
	string findInSoldierName (string name, int part) {
		int len = name.Length;
		int namePart = 1;
		int partLeft = 0; // The left-most position of the current part in the sequence.
		int partLen = 0; // The current calculated length of the part in the sequence.
		for (int i = 0; i < len; i++) {
			if (name [i] == '.') {
				namePart += 1;
				// If the next part is detected or the end of the name is reached, the for loop stops.
				if (namePart == part + 1  || i == len - 1) {
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
