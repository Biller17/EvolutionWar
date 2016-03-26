using UnityEngine;
using System.Collections;

public class unitVariables : MonoBehaviour {
	public float hp;

	void Start() {
		hp = 5f;
	}

	void Update() {
		if (hp < 0) {
			Destroy(this.gameObject);
			Debug.Log("Enemigo destruido");
			//agregar animacion de muerte de unidad
		}
	}
}
