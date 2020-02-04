using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody playerCuerpo;
    public  float force = 50;
    bool camUp = false;
    // Start is called before the first frame update
    void Start()
    {
        playerCuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setCamara();
        playerCuerpo.AddTorque(new Vector3(Input.GetAxis("Vertical") * force, transform.position.y, Input.GetAxis("Horizontal") * -force));
    }

    void setCamara()
    {
        // CHANGE CAMERA
        if(Input.GetKey(KeyCode.Tab))
            camUp = !camUp;
        if(!camUp)
            Camera.main.transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        else 
            Camera.main.transform.position = new Vector3(18, 50, 18);

    }
}
