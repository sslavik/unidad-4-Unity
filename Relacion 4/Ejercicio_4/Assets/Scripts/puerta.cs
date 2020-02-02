using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public GameObject player;
    public float  distanciaRay = 2f;
    float tDelta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tDelta += 0.5f * Time.deltaTime;
        if(tDelta > 1)
            tDelta = 0;

        Debug.DrawRay(transform.position, player.transform.position -  transform.position);
        if(Physics.Raycast(transform.position,  player.transform.position -  transform.position , distanciaRay))
        {
            Debug.Log("Encontrado");
            transform.rotation = Quaternion.Euler(0,Mathf.Lerp(transform.rotation.y,  transform.rotation.y + 90, tDelta),0);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0,Mathf.Lerp(transform.rotation.y,  transform.rotation.y - 90, tDelta),0);
        }
    }
}
