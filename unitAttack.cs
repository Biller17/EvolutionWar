using UnityEngine;
using System.Collections;

public class unitAttack : MonoBehaviour {
	private civilizationVariables civVars;
	private unitVariables enemyVars;
	private civilizationVariables enemyCivVars;
	private float currentEnemyDefense; // dependiendo si es cavalry, melee o range
	private Transform player;
	private bool attacking;
	private Vector3 dist;

	public string playerCiv;
	private string playerType;
	private string enemyCiv;

	void Start () {
		player = GetComponent<Transform> ();
		playerCiv = findInSoldierName (player.name, 3);
		playerType = findInSoldierName (player.name, 2);

		civVars = GameObject.Find ("civilizationVariableController."+playerCiv).GetComponent<civilizationVariables>();
		attacking = false;
	}

	void OnTriggerStay (Collider col)
	{
		dist = this.gameObject.transform.position;
		if (playerType == "melee") {
			if (Vector3.Distance (col.ClosestPointOnBounds(col.transform.position), dist) > civVars.melee_atk_range) 
			{
				//movimiento blablabal
			} 
			else 
			{
				if (col.gameObject.name.Contains ("unit") && !attacking) {
					GameObject enemy = col.gameObject;
					enemyCiv = findInSoldierName (enemy.name, 3);
					enemyCivVars = GameObject.Find("civilizationVariableController."+enemyCiv).GetComponent<civilizationVariables> ();
					enemyVars = enemy.GetComponent<unitVariables> ();
					string enemyType = findInSoldierName(enemy.name, 2);

					switch (enemyType) {
					case "melee":
						currentEnemyDefense = enemyCivVars.melee_def_melee;
						break;
					case "ranged":
						currentEnemyDefense = enemyCivVars.ranged_def_melee;
						break;
					case "cavalry":
						currentEnemyDefense = enemyCivVars.cavalry_def_melee;
						break;
					}
					if (enemyCiv != playerCiv) {	
						StartCoroutine (attackPlayer (civVars.melee_vel_atk, civVars, enemyVars));
						Debug.Log (enemyVars.hp);
					}
				} 
			}	
		}
	}

	IEnumerator attackPlayer(float delay, civilizationVariables playerVars, unitVariables enemy)
	{
		attacking = true;
		switch (playerType) {
		case "melee":
			enemy.hp = enemy.hp + currentEnemyDefense - playerVars.melee_atk;
			break;
		case "ranged":
			enemy.hp = enemy.hp + currentEnemyDefense - playerVars.ranged_atk;
			break;
		case "cavalry":
			enemy.hp = enemy.hp + currentEnemyDefense - playerVars.cavalry_atk;
			break;
		}
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
