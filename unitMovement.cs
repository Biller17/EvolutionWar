using UnityEngine;
using System.Collections;

public class unitMovement : MonoBehaviour {
	public Vector3 finalPos;
	private bool newOrder;
	private NavMeshAgent unit;

	void Start() {
		unit = GetComponent<NavMeshAgent> ();
		newOrder = false;
	}

	void Update () {
		if (newOrder) {
			newOrder = false;
			unit.destination = finalPos;
		}
	}

	public void SetPos(Vector3 pos) {
		finalPos = pos;
		newOrder = true;
	}
}