using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {
	private civilizationVariables civVars;
	public int maxWorkers, activeWorkers;
	public int level, type;
	public float change;

	// Use this for initialization
	void Start () {
		maxWorkers = 0;
		activeWorkers = 0;
		change = 0;
		civVars = GameObject.Find("civilizationVariableController.egypt").GetComponent<civilizationVariables>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	float getProduction(){
		return change * activeWorkers;
	}

	void changeWorker(bool add){
		if (activeWorkers == maxWorkers) {
			Debug.Log ("Max workers reached");
		} else {
			float prevProd = getProduction ();
			if(add){
				activeWorkers += 1;
			}
			else{
				activeWorkers -= 1;
			}

			if (type == 1) {
				civVars.food_rate += (getProduction() - prevProd);
			}
			
			else if (type == 2) {
				civVars.mat_rate += (getProduction() - prevProd);
			}
			
			else if (type == 3) {
				civVars.evolutionPoints_rate *= (getProduction() - prevProd);
			}
		}
	}

	void updateChange(float newChange){
		float prevProd = getProduction ();
		change = newChange;
		if (type == 1) {
			civVars.food_rate += (getProduction() - prevProd);
		}
		
		if (type == 2) {
			civVars.mat_rate += (getProduction() - prevProd);
		}
		
		if (type == 3) {
			civVars.evolutionPoints_rate *= (getProduction() - prevProd);
		}
	}
	
}










