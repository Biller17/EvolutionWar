using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selectUnits : MonoBehaviour {
    private controlBinds controls;

    public Vector3 initialPos;

	private float x1,x2,z1,z2;
	private bool assigned;

    public float disBetweenUnits;

	List<GameObject> selectedUnits;

    void Start () {
        // Very important to have this in every script that uses Input. It is the global setting for controls.
        controls = GameObject.Find("gameVariableController").GetComponent<controlBinds>();

        assigned = false;

        disBetweenUnits = 0.4f;

        selectedUnits = new List<GameObject>();

        initialPos = Vector3.forward;
    }

	void Update () {
		Ray pos = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

        if (Input.GetKeyDown(controls.mouse0)) {
            selectedUnits.Clear();
			if (Physics.Raycast (pos, out hit)) {
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
	}

	void OnMouseUp() {
		assigned = false;
		select ();
	}

	void select() {
        Vector3 unitPos;
		foreach (GameObject unit in GameObject.FindObjectsOfType(typeof(GameObject))) {
			unitPos = unit.GetComponent<Transform>().position;
			if (unit.name.Contains ("unit") && inSelection(unitPos))
				selectedUnits.Add (unit);
		}
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
		GameObject soldier;

		int soldierIndex = 0;
		int cols = 0;
		int rowUnits = 0;
		int maxC = 0;
		int maxR = 0;

		Vector3 initialPosition;
		Vector3 rotatedPosition;

		// Depending on the size of the group, the amount of columns changes
		if (selectedUnits.Count <= 16) {
			cols = 4;
		} else {
			cols = 6;
		}

	// Finding the angle to aim the crowd
		// Find the middle point of the group selected
		initialPos = Vector3.zero;
		if (selectedUnits.Count >= cols) {
			for (int i = 0; i < cols; i++) {
				initialPos += selectedUnits [i].transform.position;
			}
			rowUnits = cols;
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
		  // maxR is the max number of rows that can be made from the group selected.
		maxR = Mathf.CeilToInt (((float)selectedUnits.Count + 1) / (float)cols);

		for (int i = 0; i < maxR; i++) {
			// each row has a different number of units. If 13 units are selected, the last row will have 1 unit.
			if (cols * (i + 1) > selectedUnits.Count) {
				rowUnits = selectedUnits.Count - (i * cols);
			} else {
				rowUnits = cols;
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