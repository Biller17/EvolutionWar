using UnityEngine;
using System.Collections;

public class unitAttack : MonoBehaviour {
	private unitVariables unitPlayer;
	private unitVariables unitEnemy;
	private float currentEnemyDefense; // dependiendo si es cavalry, melee o range
	private Transform player;
	private bool attacking;

	void Start () {
		player = GetComponent<Transform> ();
		unitPlayer = GetComponent<unitVariables> ();
		attacking = false;
	}


	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.name.Contains ("unit") && !attacking) {
			GameObject enemy = col.gameObject;
			unitEnemy = enemy.GetComponent<unitVariables> ();

			switch(player.name)
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
				StartCoroutine(attackPlayer (unitPlayer.vel_atk, unitPlayer, unitEnemy));
				Debug.Log (unitEnemy.hp);
			}
		} 
	}


	void Update () 
	{} 

	IEnumerator attackPlayer(float delay, unitVariables player, unitVariables enemy)
	{
		attacking = true;
		enemy.hp = enemy.hp+currentEnemyDefense - player.atk;
		yield return new WaitForSeconds (delay);
		attacking = false;
	}
}
