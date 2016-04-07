using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selectUnits : MonoBehaviour {
    private controlBinds controls;

	private civilizationVariables civVariables;
	public string civ;

    private Vector3 initialPos;

	private float x1,x2,z1,z2;
	private bool assigned;

	private float disBetweenUnits;

	List<GameObject> selectedUnits, cavalry, melee, ranged;

    void Start () {
        // Very important to have this in every script that uses Input. It is the global setting for controls.
        controls = GameObject.Find("gameVariableController").GetComponent<controlBinds>();
		civVariables = GameObject.Find ("civilizationVariableController."+civ).GetComponent<civilizationVariables>();

        assigned = false;

        disBetweenUnits = 0.4f;

        selectedUnits = new List<GameObject>();
		cavalry = new List<GameObject> ();
		melee = new List<GameObject> ();
		ranged = new List<GameObject> ();

        initialPos = Vector3.forward;
    }

	void Update () {
		// Removes any soldiers from the selected list if they have been killed already.
		List<GameObject> temp = new List<GameObject>();
		foreach (GameObject soldier in cavalry) {
			if (soldier == null)
				temp.Add (soldier);
		}
		foreach (GameObject deadSoldier in temp) {
			selectedUnits.Remove(deadSoldier);
			cavalry.Remove (deadSoldier);
		}
		temp.Clear ();
		foreach (GameObject soldier in melee) {
			if (soldier == null)
				temp.Add (soldier);
		}
		foreach (GameObject deadSoldier in temp) {
			selectedUnits.Remove(deadSoldier);
			melee.Remove (deadSoldier);
		}
		temp.Clear ();
		foreach (GameObject soldier in ranged) {
			if (soldier == null)
				temp.Add (soldier);
		}
		foreach (GameObject deadSoldier in temp) {
			selectedUnits.Remove(deadSoldier);
			ranged.Remove (deadSoldier);
		}

		Ray pos = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

        if (Input.GetKeyDown(controls.mouse0)) {
            selectedUnits.Clear();
			cavalry.Clear();
			melee.Clear();
			ranged.Clear();
			if (Physics.Raycast (pos, out hit)) {
				Debug.Log (hit.transform.name);
				if (hit.transform.name.Contains ("unit")) {
					selectedUnits.Add (hit.transform.gameObject);
				}
			}
		}

		if (Input.GetKeyDown(controls.mouse1) && selectedUnits.Count != 0) {
			if(Physics.Raycast(pos, out hit)) {
                formationMove(hit.point);
            }
		}
	}

	void OnMouseDrag() {
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
		Debug.Log ("rangex " + x1 + ":" + x2 + ", rangez " + z1 + ":" + z2 + ", selected " + selectedUnits.Count);
	}

	void OnMouseUp() {
		assigned = false;
		select ();
	}

	void select() {
        Vector3 unitPos;
		foreach (GameObject unit in GameObject.FindObjectsOfType(typeof(GameObject))) {
			unitPos = unit.GetComponent<Transform>().position;
			if (unit.name.Contains ("cavalry") && inSelection(unitPos))
				cavalry.Add (unit);
			if (unit.name.Contains ("melee") && inSelection(unitPos))
				melee.Add (unit);
			if (unit.name.Contains ("ranged") && inSelection(unitPos))
				ranged.Add (unit);
		}

		foreach (GameObject soldier in cavalry)
			selectedUnits.Add (soldier);
		foreach (GameObject soldier in melee)
			selectedUnits.Add (soldier);
		foreach (GameObject soldier in ranged)
			selectedUnits.Add (soldier);
	}

	bool inSelection(Vector3 position) {
		// Top left to bottom right
		if (x2 > x1 && z1 > z2) {
			if ((position.x > x1 && position.x < x2) && (position.z < z1 && position.z > z2))
				return true;
		} // Top right to bottom left
		else if (x1 > x2 && z1 > z2) {
			if ((position.x > x2 && position.x < x1) && (position.z < z1 && position.z > z2))
				return true;
		} // Bottom right to top left
		else if (x1 > x2 && z2 > z1) {
			if ((position.x > x2 && position.x < x1) && (position.z < z2 && position.z > z1))
				return true;
		} // Bottom left to top right
		else if (x2 > x1 && z2 > z1) {
			if ((position.x > x1 && position.x < x2) && (position.z < z2 && position.z > z1))
				return true;
		}

		return false;
	}

	void formationMove (Vector3 finalPos) {
		int cols = 0, colsC, colsM, colsR, maxR, rowsC = 0, rowsM = 0, rowsR = 0;

		GameObject soldier;

		int soldierIndex = 0;
		int rowUnits = 0;
		int maxC = 0;

		Vector3 initialPosition;
		Vector3 rotatedPosition;

		// Depending on the size of the group, the amount of columns changes
		if (cavalry.Count <= 16) { colsC = 4; } else { colsC = 6; }
		if (melee.Count <= 16) { colsM = 4; } else { colsM = 6; }
		if (ranged.Count <= 16) { colsR = 4; } else { colsR = 6; }

		maxR = 0;
		if (cavalry.Count != 0) {
			rowsC = Mathf.CeilToInt (((float)cavalry.Count) / (float)colsC);
			maxR += rowsC;
			cols = colsC;
		}
		if (melee.Count != 0) {
			rowsM = Mathf.CeilToInt (((float)melee.Count) / (float)colsM);
			maxR += rowsM;
			if (cols == 0) { cols = colsM; }
		}
		if (ranged.Count != 0) {
			rowsR = Mathf.CeilToInt (((float)ranged.Count) / (float)colsR);
			maxR += rowsR;
			if (cols == 0) { cols = colsR; }
		}

		// Finding the angle to aim the crowd
			// Find the middle point of the group selected
		initialPos = Vector3.zero;
		if (selectedUnits.Count >= colsC) {
			for (int i = 0; i < colsC; i++) {
				initialPos += selectedUnits [i].transform.position;
			}
			rowUnits = colsC;
		} else {
			for (int i = 0; i < selectedUnits.Count; i++) {
				initialPos += selectedUnits [i].transform.position;
			}
			rowUnits = selectedUnits.Count;
		}
		initialPos = initialPos / rowUnits;

		// Find the angle between 0 and 360 from the middle point of the selected group to the final position
		Vector2 start = new Vector2 (initialPos.x, initialPos.z);
		Vector2 end = new Vector2 (finalPos.x, finalPos.z);

		Vector2 directionV = end - start;
		Vector2 upV = Vector2.up;

		float angle = Vector2.Angle (upV, directionV);
		Vector3 cross = Vector3.Cross (upV, directionV);

		if (cross.z > 0)
			angle = 360 - angle;

		// Find the sine and cosine of the angle for future calculations (rotation tranform of the formation).
		float cosine = Mathf.Cos (angle * Mathf.Deg2Rad);
		float sine = Mathf.Sin (angle * Mathf.Deg2Rad);

		// With the angle correctly calculated, we create the formation in the direction of the angle.
		rowUnits = 0;

		int cavUnits = cavalry.Count;
		int melUnits = melee.Count;
		int ranUnits = ranged.Count;

		for (int i = 0; i < maxR; i++) {
			// each row has a different number of units. If 13 cavalry units are selected, the last row of cavalry will have 1 unit.
			if (soldierIndex < cavalry.Count) {
				if (cavUnits - colsC > 0) {
					rowUnits = colsC;
					cavUnits -= colsC;
				} else {
					rowUnits = cavUnits;
				}
			} else if (soldierIndex < cavalry.Count+melee.Count) {
				if (melUnits - colsM> 0) {
					rowUnits = colsM;
					melUnits -= colsM;
				} else {
					rowUnits = melUnits;
				}
			} else {
				if (ranUnits - colsR > 0) {
					rowUnits = colsR;
					ranUnits -= colsR;
				} else {
					rowUnits = ranUnits;
				}
			}

			// The units are positioned with an offset (j / j + 0.5) if the number of units in the row is even or odd.
			if ((rowUnits % 2) == 1) {
				// maxC holds the number of units that will be to the right and left of the final position for each row.
				maxC = Mathf.FloorToInt (rowUnits / 2);
				for (int j = -maxC; j <= maxC; j++) {
					// initialPosition refers to the position of the unit in the formation if the formation were facing north.
					initialPosition = new Vector3 (j * disBetweenUnits, 0, -i * disBetweenUnits);
					// rotatedPosition is the position of the unit after taking into account the direction the formation is looking at.
					rotatedPosition = new Vector3 (
						-(initialPosition.x * cosine - initialPosition.z * sine), 
						0, 
						initialPosition.x * sine + initialPosition.z * cosine);

					// The following lines move one unit to its correct position and increments the index of the selected group for the next unit.
					soldier = selectedUnits [soldierIndex];
					soldier.GetComponent<unitMovement> ().SetPos (finalPos + rotatedPosition);
					soldierIndex++;
				}
			} else {
				maxC = rowUnits / 2;
				for (int j = -maxC; j < maxC; j++) {
					initialPosition = new Vector3 ((j + 0.5f) * disBetweenUnits, 0, -i * disBetweenUnits);
					rotatedPosition = new Vector3 (
						-(initialPosition.x * cosine - initialPosition.z * sine), 
						0, 
						initialPosition.x * sine + initialPosition.z * cosine);

					soldier = selectedUnits [soldierIndex];
					soldier.GetComponent<unitMovement> ().SetPos (finalPos + rotatedPosition);
					soldierIndex++;
				}
			}
		}
	}
}