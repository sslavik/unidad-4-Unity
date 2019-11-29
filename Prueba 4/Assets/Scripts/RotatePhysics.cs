using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePhysics  : MonoBehaviour {

	// CAMPOS
	public float fuerzaAplicada = 50;
	public float impulso;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// CON EL TORQUE PERMITIMOS EL GIRO DEL ELMENTO
		// Se usar Torque para añarir rotación al objeto
		GetComponent<Rigidbody>().AddTorque(Vector3.up * fuerzaAplicada * Time.deltaTime * Input.GetAxis("Horizontal"), ForceMode.Force);
		GetComponent<Rigidbody>().AddTorque(Vector3.forward * fuerzaAplicada * Time.deltaTime * Input.GetAxis("Vertical"), ForceMode.Force);
	}
}
