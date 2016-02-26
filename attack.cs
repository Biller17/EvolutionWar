using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public unit unitPlayer;
	public unit unitEnemy;
	public int isEnemy;
	public string enemyName;
	public string enemyType;


	void Start () {
		GameObject player = GameObject.Find ("unit");
		unitPlayer = player.GetComponent<unit> ();
	}


	void OnCollisionEnter (Collision col) //on collision stay
	{
		if (col.gameObject.name.Contains ("unit")) {
			GameObject enemy = col.gameObject;
			unitEnemy = enemy.GetComponent<unit> ();
			if (unitEnemy.civ != unitPlayer.civ) {
				isEnemy = 1;
				enemyName = unitEnemy.transform.name;
				enemyType = unitEnemy.transform.tag;
			}
		} 
	}

	void OnTriggerEnter (Collider col)
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		if (isEnemy == 1) {
			GameObject enemy = GameObject.Find(enemyName);
			unitEnemy = enemy.GetComponent<unit> ();

		}
		Debug.Log (unitPlayer.atk);
		Debug.Log (unitEnemy.atk);
		StartCoroutine(wait(unitPlayer.vel_atk));
		unitEnemy.hp = -unitPlayer.atk;
	} 

	IEnumerator wait(float delay)
	{
		yield return new WaitForSeconds (delay);
	}

}