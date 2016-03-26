using UnityEngine;
using System.Collections;

public class evolutionUpgrades : MonoBehaviour {
	private civilizationVariables civVars;
	// Use this for initialization
	void Start () {
		civVars = GameObject.Find("civilizationVariableController.egypt").GetComponent<civilizationVariables>();
	}

	// Update is called once per frame
	void Update () {}

	// CLASSIC UPGRADES
	void unlockAgriculture(){
		// Unlock farm lvl1
		//adds 2 food per habitant
		//adds 5 habitants

	}

	void unlockHouses(){
		// Unlock house lvl1
		civVars.habitants += 10;
	} 

	void unlockForest(){
		// Unlock forest lvl1
		//adds 1 material per habitant
		//adds 2 habitants

	}

	void unlockMarket(){
		// Unlock market and trading
	}

	void unlockWall(){
		//adds 5hp / 1 def
	}

	void unlockTemple(){
		// Unlock temple
		//mult 1.05 of production
	}

	void unlockAgora(){
		// Unlock agora
		//+ 2 habitants
		//mul 1.1 EP
	}

	void unlockIrrigation()
	{
		//adds food to farms
	}
		
	void unlockCaste()
	{
		//adds gold
	}

	void unlockMines()
	{
		//adds 1.6 materials per habitant
		//adds 15 habitants
	}

	void unlockBlacksmith()
	{
		//adds materials
	}
	void unlockChurch()
	{
		//mult 1.5 EP
	}

	void unlockCastle()
	{
		//adds 0.5 atk
	}

	void unlockLecture()
	{
		//mult 1.1 EP
	}

	void unlockNavigation()
	{
		//better market deals
	}

}
