using UnityEngine;
using System.Collections;

public class buildingUpgrade : MonoBehaviour {
	private civilizationVariables civVars;

	// Use this for initialization
	void Start () {
		civVars = GameObject.Find("civilizationVariableController.egypt").GetComponent<civilizationVariables>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* CLASSIC ERA */

	void houseLvl2() {
		civVars.gold -= 50;
		civVars.population += 20;
		civVars.workers += 20;
		civVars.idleWorkers += 20;
	}

	void houseLvl3() {
		civVars.gold -= 100;
		civVars.materials -= 10;
		civVars.population += 30;
		civVars.workers += 30;
		civVars.idleWorkers += 30;
	}

	void agricultureLvl2() {
		civVars.gold -= 100;
		// 2.5 cmd/hab and 10 workers assignable, type 1
	}

	void agricultureLvl3() {
		civVars.gold -= 100;
		// 3 cmd/hab and 20 workers assignable, type 1
	}

	void woodLvl2() {
		civVars.gold -= 50;
		civVars.food -= 20;
		// 1.25mat/hab and 5 workers assignable, type 2
	}

	void woodLvl3() {
		civVars.gold -= 100;
		civVars.food -= 50;
		// 1.5mat/hab and 10 workers assignable, type 2
	}

	void templeLvl2() {
		civVars.gold -= 200;
		// *1.1 EP prod, type 3
	}

	void templeLvl3() {
		civVars.gold -= 300;
		// *1.25 EP prod, type 3
	}

	void agoraLvl2() {
		civVars.gold -= 50;
		civVars.food -= 50;
		civVars.materials -= 10;
		civVars.population += 3;
		civVars.workers += 3;
		civVars.idleWorkers += 3;
		// *1.2 EP type 3
	}

	void agoraLvl3() {
		civVars.gold -= 100;
		civVars.food -= 100;
		civVars.materials -= 50;
		civVars.population += 5;
		civVars.workers += 5;
		civVars.idleWorkers += 5;
		// *1.3 EP type 3
	}


	/* MEDIEVAL ERA */
	void houseLvl4() {
		civVars.gold -= 200;
		civVars.materials -= 10;
		civVars.population += 30;
		civVars.workers += 30;
		civVars.idleWorkers += 30;
	}

	void houseLvl5() {
		civVars.gold -= 300;
		civVars.materials -= 50;
		civVars.population += 40;
		civVars.workers += 40;
		civVars.idleWorkers += 40;
	}

	void houseLvl6() {
		civVars.gold -= 500;
		civVars.materials -= 100;
		civVars.population += 50;
		civVars.workers += 50;
		civVars.idleWorkers += 50;
	}

	void mineLvl2() {
		civVars.gold -= 500;
		// 1.7mat/hab, 20 habs type 2
	}

	void mineLvl3() {
		civVars.gold -= 1000;
		// 1.8mat/hab, 25 habs type 2
	}

	void churchLvl2() {
		civVars.gold -= 300;
		civVars.food -= 300;
		civVars.materials -= 50;
		// *2EP type 3
	}

	void churchLvl3() {
		civVars.gold -= 500;
		civVars.food -= 500;
		civVars.materials -= 200;
		// *3EP type 3
	}
	







	

}
