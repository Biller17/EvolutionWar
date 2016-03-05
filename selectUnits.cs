using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selectUnits : MonoBehaviour {
	private bool selectedIndividual;
	private bool selectedGroup;
	private string selectedName;
	private GameObject soldier;

	private float x1,x2,z1,z2;
	private bool assigned;

    private controlBinds controls;

	List<GameObject> selectedUnits;

	private Vector3 unitPos;

    // Use this for initialization
    void Start () {
        // Very important to have this in every script that uses Input. It is the global setting for controls.
        controls = GameObject.Find("gameVariableController").GetComponent<controlBinds>();

        assigned = false;
        selectedUnits = new List<GameObject>();
    }

	// Update is called once per frame
	void Update () {
		Ray pos = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetKeyDown(controls.mouse0)) {
			if(Physics.Raycast(pos,out hit)) {
				if(hit.transform.name.Contains("unit")){
					selectedName = hit.transform.name;
					selectedIndividual = true;
				} else {
					selectedIndividual = false;
					selectedGroup = false;
					selectedUnits.Clear ();
				}
			}
		}

		if (Input.GetKeyDown(controls.mouse1) && (selectedIndividual || selectedGroup)) {
			if(Physics.Raycast(pos, out hit)) {
				if (selectedIndividual) {
					soldier = GameObject.Find (selectedName);
					soldier.GetComponent<unitMovement>().SetPos(hit.point); 
				} else {
/*					foreach (GameObject soldier in selectedUnits) {
						soldier.GetComponent<unitMovement>().SetPos(hit.point);
					}	*/
					formationMove (hit.point);
				}
			}
		}
	}

	void OnMouseDrag(){
		Ray pos = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		Physics.Raycast (pos, out hit);

		if (!assigned) {
			x1 = hit.point.x;
			z1 = hit.point.z;
			assigned = true;
		}
		x2 = hit.point.x;
		z2 = hit.point.z;
		//Debug.Log (x1 + " " + z1 + " "+ x2 + " " + z2);
	}

	void OnMouseUp() {
		assigned = false;
		select ();
		if (selectedUnits.Count > 0)
			selectedGroup = true;
	}

	void select() {
		foreach (GameObject unit in GameObject.FindObjectsOfType(typeof(GameObject))) {
			unitPos = unit.GetComponent<Transform>().position;
			if (unit.name.Contains ("unit") && inSelection(unitPos))
				selectedUnits.Add (unit);
		}
	}

	bool inSelection(Vector3 position) {
		// De arriba izquierda a abajo derecha
		if (x2 > x1 && z1 > z2) {
			if ((position.x > x1 && position.x < x2) && (position.z < z1 && position.z > z2))
				return true;
		}
		else if (x1 > x2 && z1 > z2) {
			if ((position.x > x2 && position.x < x1) && (position.z < z1 && position.z > z2))
				return true;
		}
		else if (x1 > x2 && z2 > z1) {
			if ((position.x > x2 && position.x < x1) && (position.z < z2 && position.z > z1))
				return true;
		}
		else if (x2 > x1 && z2 > z1) {
			if ((position.x > x1 && position.x < x2) && (position.z < z2 && position.z > z1))
				return true;
		}

		return false;
	}

	void formationMove (Vector3 finalPos) {
		int soldierIndex = 0;
		int cols = 0;
		int rowUnits = selectedUnits.Count;
		int maxC = 0;
		int maxR = 0;

		if (selectedUnits.Count <= 16) {
			cols = 4;
		} else {
			cols = 6;
		}
			
		maxR = Mathf.CeilToInt ((selectedUnits.Count+1) / cols);
		for (int i = 0; i < maxR; i++) {
            if (cols * (i + 1) > selectedUnits.Count) {
                rowUnits = selectedUnits.Count - (i * cols);
            } else {
                rowUnits = cols;
            }

            if ((rowUnits % 2) == 1) {
				maxC = Mathf.FloorToInt (rowUnits / 2);
				for (int j = -maxC; j <= maxC; j++) {
					soldier = selectedUnits [soldierIndex];
					soldier.GetComponent<unitMovement> ().SetPos (finalPos + new Vector3 (-i, 0, j));
					soldierIndex++;
				}
			} else {
				maxC = rowUnits / 2;
				for (int j = -maxC; j < maxC; j++) {
            		soldier = selectedUnits [soldierIndex];
					soldier.GetComponent<unitMovement> ().SetPos (finalPos + new Vector3 (-i, 0, j+0.5f));
					soldierIndex++;
				}
			}
		}
	}
}
