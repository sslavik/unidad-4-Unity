using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ball")
            Destroy(other.gameObject);
        if(other.gameObject.tag == "white"){
            other.gameObject.transform.position = new Vector3(0,0,0);
            other.rigidbody.velocity = new Vector3(0,0,0);
        }
           
    }
}
