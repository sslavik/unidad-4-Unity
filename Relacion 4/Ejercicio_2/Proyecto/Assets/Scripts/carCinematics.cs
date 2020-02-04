using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCinematics : MonoBehaviour
{
    // Start is called before the first frame update
    static bool active = false;
    bool jump = false;
    public Camera cam2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            CarMovement();
            CameraControl();
        }
        if(jump){
            transform.position = new Vector3(transform.position.x,Mathf.PingPong(Time.time * 2, 1) + 0.40f,transform.position.z);
            if(transform.position.y <= 0.5f)
            {
                jump = false;
                transform.position = new Vector3(transform.position.x,0.53f, transform.position.z);
            }
        }
            
            
    }

    void CarMovement()
    {
        transform.Translate(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Space)){
            jump = true;
        }
    }

    void CameraControl()
    {
        cam2.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z - 5);
    }

    public static void ActiveMovement(){
        active = true;
    }

    public static void DeactiveMovement(){
        active = false;
    }
}
