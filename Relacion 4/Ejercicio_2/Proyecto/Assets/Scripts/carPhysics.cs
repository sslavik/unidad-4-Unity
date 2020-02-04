using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class carPhysics : MonoBehaviour
{
    // CAMPOS

    public WheelCollider FWRight;
    public WheelCollider FWLeft;
    public WheelCollider RWRight;
    public WheelCollider RWLeft;
    public float velocidad = 120;
    static bool active = true;
    public Camera cam1;
    Rigidbody carBody;
    public float forceJump = 20000;

    // Start is called before the first frame update
    void Start()
    {
        carBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(active){
            WheelsControl();
            CameraControl();
            if(Input.GetKeyDown(KeyCode.Space))
                carBody.AddForce(0,forceJump,0);
        }
        
    }

    void WheelsControl(){
        
        //FWLeft.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"),0), (Input.GetAxis("Horizontal") * 20));
        //FWRight.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"),0), (Input.GetAxis("Horizontal") * 20));
        FWLeft.transform.rotation = Quaternion.Euler(FWLeft.transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + (Input.GetAxis("Horizontal") * 20),transform.rotation.eulerAngles.z);
        FWRight.transform.rotation = Quaternion.Euler(FWRight.transform.rotation.eulerAngles.x ,transform.rotation.eulerAngles.y + (Input.GetAxis("Horizontal") * 20),transform.rotation.eulerAngles.z);
        
        FWLeft.transform.Rotate(Vector3.right, gameObject.GetComponent<Rigidbody>().velocity.magnitude*2);
        FWRight.transform.Rotate(Vector3.right, gameObject.GetComponent<Rigidbody>().velocity.magnitude*2);
        RWLeft.transform.Rotate(Vector3.right, gameObject.GetComponent<Rigidbody>().velocity.magnitude*2);
        RWRight.transform.Rotate(Vector3.right, gameObject.GetComponent<Rigidbody>().velocity.magnitude*2);

        RWLeft.steerAngle = Input.GetAxis("Horizontal") * -20;
        RWRight.steerAngle = Input.GetAxis("Horizontal") * -20;

        RWLeft.motorTorque = Input.GetAxis("Vertical") * velocidad;
        RWRight.motorTorque = Input.GetAxis("Vertical") * velocidad;



        Debug.Log(" MOTOR : " + RWRight.motorTorque);
        Debug.Log(" VELOCIDAD : " + gameObject.GetComponent<Rigidbody>().velocity.magnitude);
    }

    void CameraControl(){
        if(transform.rotation.eulerAngles.z > 0 ){
            cam1.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 10,
            transform.rotation.eulerAngles.y,
            cam1.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z );
        }
        if(transform.rotation.eulerAngles.z < 0 ){
            cam1.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 10,
            transform.rotation.eulerAngles.y,
            cam1.transform.rotation.eulerAngles.z + transform.rotation.eulerAngles.z );
        }
        else {
            cam1.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 10,
            transform.rotation.eulerAngles.y,
            0 );
        }
        
    }
    public static void ActiveMovement(){
         active = true;
    }

    public static void DeactiveMovement(){
        active = false;
    }
}
