using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody playerCuerpo;
    public  float force = 50;
    // Start is called before the first frame update
    void Start()
    {
        playerCuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerCuerpo.AddTorque(new Vector3(Input.GetAxis("Vertical") * force, transform.position.y, Input.GetAxis("Horizontal") * -force));
    }
}
