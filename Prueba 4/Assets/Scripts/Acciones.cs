using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acciones : MonoBehaviour {
	//campos
	float tiempoTotal;
	Rigidbody rbG0;
	bool durmiendo;


	// Use this for initialization
	void Start () {
		rbG0 = gameObject.AddComponent<Rigidbody>();
		rbG0.mass = 10;
		Physics.gravity = new Vector3(0,-20,0);
		durmiendo = true;
		tiempoTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(tiempoTotal > 1){
			if(durmiendo){
				rbG0.WakeUp();
				Debug.Log("Despierto - WakeUP()");
			}
			else {
				rbG0.Sleep();
				Debug.Log("Dormido - Sleep()");
			}
			durmiendo = !durmiendo;
			tiempoTotal = 0;
		}
		tiempoTotal += Time.deltaTime;
	}
}
