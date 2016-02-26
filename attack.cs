using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public unit unitPlayer;
	public unit unitEnemy;
	public float currentEnemyDefense; // dependiendo si es cavalry, melee o range
	void Start () {
		GameObject player = GameObject.Find ("unit");
		unitPlayer = player.GetComponent<unit> ();
	}


	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.name.Contains ("unit")) {
			GameObject enemy = col.gameObject;
			unitEnemy = enemy.GetComponent<unit> ();

			switch(unitPlayer.tag)
			{
			case "melee":
				currentEnemyDefense = unitEnemy.def_melee;
				break;
			case "range":
				currentEnemyDefense = unitEnemy.def_range;
				break;
			case "cavalry":
				currentEnemyDefense = unitEnemy.def_cavalry;
				break;
			}

			if (unitEnemy.civ != unitPlayer.civ) 
			{
				wait (unitPlayer.vel_atk);
				unitEnemy.hp -= unitPlayer.atk + currentEnemyDefense;
			}
		} 
	}

	// Update is called once per frame
	void Update () 
	{} 

	IEnumerator wait(float delay)
	{
		yield return new WaitForSeconds (delay);
	}
}