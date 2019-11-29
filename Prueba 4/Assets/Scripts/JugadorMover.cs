using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorMover : MonoBehaviour {

	//CAMPOS
	public float fuerza = 30F;
	public Text mensaje;
	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();// OBTIENE EL COMPONENTE DEL OBJETO QUE TIENE EL SCRIPTS
	}
	
	// FixedUpdate es recomendable para usarlo con físicas
	void FixedUpdate () {
		rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal")*fuerza, transform.position.y ,Input.GetAxis("Vertical")*fuerza),
		ForceMode.Force); // AÑADIMOS EL TIPO DE FUERZA
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemigo")
			Destroy(other.gameObject);
		mensaje.text = other.collider.name + ", Detectado enemigo";
	}

}
