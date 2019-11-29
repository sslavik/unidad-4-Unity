using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Se produce cuando entra en contacto con otro Collider
	void OnCollisionEnter(Collision other) {
		Debug.LogFormat("ENTER: Colisionado con {0}", other.collider.name);
	}
	
	// Se produce cuando la colisión es constante con el otro Collider
	void OnCollisionStay(Collision other) {
		Debug.LogFormat("STAY: Colisionado con {0}", other.collider.name);

	}

	// Se produce cuando se termina la colisión con el otro Collider
	void OnCollisionExit(Collision other) {
		Debug.LogFormat("EXIT: Colisionado con {0}", other.collider.name);

	}

}
