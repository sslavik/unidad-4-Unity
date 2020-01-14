using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;





public class RelojExamen : MonoBehaviour {

	// CAMPO

	public GameObject hora;
	public GameObject minuto;
	public GameObject segundos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DateTime now = DateTime.Now;

		float rotationHor = ( 360 * (now.Hour * 60) ) / 720 ;
		float rotationMin  = 360 / 60 * now.Minute;
		float rotationSeg  = 360 / 60 * now.Second * -1;

		hora.transform.rotation = Quaternion.Euler(rotationHor,-90,90);
		minuto.transform.rotation = Quaternion.Euler(rotationMin,-90,90);
		segundos.transform.rotation = Quaternion.Euler(rotationSeg,-90,90);

	}
}
