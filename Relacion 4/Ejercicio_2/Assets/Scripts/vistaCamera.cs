using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vistaCamera : MonoBehaviour
{  
    Camera mainCamera;
    float leftViewPort;
    float upViewPort;
    float rightViewPort;
    float downViewPort;
    public float mouseMovementDetection = 50;
    Ray ray;
    public Camera c1;
    public Camera c2;
    // Start is called before the first frame update
    void Start()
    {
        c1.enabled = true;
        c2.enabled = false;
        mainCamera =GetComponent<Camera>();
        leftViewPort = 0;
        rightViewPort = Camera.main.pixelWidth;
        upViewPort = Camera.main.pixelHeight;
        downViewPort = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //cameraMovement();
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray, out RaycastHit info))
            {
                Debug.Log("HELLO" + info.collider.name);
            }
        }
        
    }

    void cameraMovement()
    {
        if(Input.mousePosition.x < mouseMovementDetection)
            transform.Rotate(Vector3.down, 1);
        if(Input.mousePosition.x > rightViewPort - mouseMovementDetection)
            transform.Rotate(Vector3.up,  1);
    }

    public void carCinematicActive()
    {
        c1.enabled = false;
        c2.enabled = true;
        carCinematics.ActiveMovement();
        carPhysics.DeactiveMovement();
    }

    public void carPhysicsActive(){
        c1.enabled = true;
        c2.enabled = false;
        carCinematics.DeactiveMovement();
        carPhysics.ActiveMovement();
    }

    public void resetScene(){
        SceneManager.LoadScene("PhysicsAndCinematic");
    }
}
