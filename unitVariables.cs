using UnityEngine;
using System.Collections;

public class unitVariables : MonoBehaviour {
	public float atk, atk_range, view_range;
	public float def_melee, def_cavalry, def_range;
	public float vel_walk, vel_atk;
	public float hp;
	public string civ;
	public SphereCollider attackCol;
	
	// Use this for initialization
	void Start () {
		if (this.gameObject.tag == "melee") {
			Debug.Log ("atributos melee asignados");
			hp = 10.0f;
			atk = 3.0f;
			atk_range = 2.0f;
			view_range = 7.0f;
			def_melee = 1.0f;
			def_range = 1.2f;
			def_cavalry = 0.5f;
			vel_walk = 1.0f;


			vel_atk = 2.0f;
			attackCol = this.gameObject.AddComponent<SphereCollider> ();
			attackCol.center = Vector3.zero;
			attackCol.radius = view_range;
			attackCol.isTrigger = true;
		}
		if (this.gameObject.tag == "range") {
			Debug.Log ("atributos range asignados");
			hp = 5.0f;
			atk = 2.0f;
			atk_range = 5.0f;
			view_range = 10.0f;
			def_melee = 0.5f;
			def_range = 1.0f;
			def_cavalry = 1.0f;
			vel_walk = 2.0f;
			vel_atk = 3.0f;
			attackCol = this.gameObject.AddComponent<SphereCollider> ();
			attackCol.center = Vector3.zero;
			attackCol.radius = view_range;
			attackCol.isTrigger = true;

		}
		if (this.gameObject.tag == "cavalry") {
			Debug.Log ("atributos cavalry asignados asignados");
			hp = 15.0f;
			atk = 5.0f;
			atk_range = 3.0f;
			view_range = 10.0f;
			def_melee = 1.0f;
			def_range = 0.5f;
			def_cavalry = 1.0f;
			vel_walk = 4.0f;
			vel_atk = 2.0f;
			attackCol = this.gameObject.AddComponent<SphereCollider> ();
			attackCol.center = Vector3.zero;
			attackCol.radius = view_range;
			attackCol.isTrigger = true;
		}
	}
	void Update () {

		if (hp < 0) {
			Destroy(this.gameObject);
			Debug.Log("Enemigo destruido");
			//agregar animacion de muerte de unidad
		}

	
	}
}
