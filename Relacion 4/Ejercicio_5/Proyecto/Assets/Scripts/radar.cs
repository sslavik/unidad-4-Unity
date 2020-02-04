using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radar : MonoBehaviour
{
    public GameObject laser;
    public GameObject mira;
    public Image punto;
    Canvas radarMapa;
    Vector3 rayDestino;
    // Start is called before the first frame update
    void Start()
    {
        radarMapa = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        // GIRO
        mira.transform.RotateAround(laser.transform.position, Vector3.up, 1);
        laser.transform.Rotate(Vector3.forward);

        // MAPEO
        if(Physics.Raycast(laser.transform.position, mira.transform.position - laser.transform.position, out RaycastHit info ,Mathf.Infinity)){
            Debug.Log(info.collider.name);
            Debug.DrawRay(laser.transform.position, mira.transform.position - laser.transform.position);
            Image i = Instantiate(punto);
            i.transform.SetParent(radarMapa.transform, false);
            i.rectTransform.localPosition = new Vector3(info.transform.position.x * 17.5f, info.transform.position.y * 17.5f,0);
        }
    }
}
