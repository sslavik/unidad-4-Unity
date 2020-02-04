using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // CAMPOS
    public Camera cam1;
    public GameObject punta;
    public float force = 50;
    Rigidbody ballBody;

    // COLLISIONS
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        ballBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ballBody.AddTorque(new Vector3(Input.GetAxis("Vertical") * force,
        0,
        Input.GetAxis("Horizontal") * -force));
        setCamara();
    }

    void setCamara()
    {
        float ballPosX = transform.position.x;
        float ballPosY = transform.position.y;
        float ballPosZ = transform.position.z;
        cam1.transform.position = new Vector3(
            ballPosX,
            cam1.transform.position.y,
            ballPosZ - 4
            );
    }
    // Usamos el componente "Renderer" para poder acceder a Material y al mismo tiempo al color de este
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "cubo")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
            Debug.Log("Entra colisión con un Cubo : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "esfera")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
            Debug.Log("Entra colisión con una Esfera : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "cilindro")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
            Debug.Log("Entra colisión con un Cilindro : " + other.gameObject.name);
        }
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "cubo")
        {
            Debug.Log("Mantiene colisión con un Cubo : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "esfera")
        {
            Debug.Log("Mantiene colisión con una Esfera : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "cilindro")
        {
            Debug.Log("Mantiene colisión con un Cilindro : " + other.gameObject.name);
        }
    }

     private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "cubo")
        {
            Debug.Log("Sale de colisión con un Cubo : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "esfera")
        {
            Debug.Log("Sale de colisión con una Esfera : " + other.gameObject.name);
        }
         if(other.gameObject.tag == "cilindro")
        {
            Debug.Log("Sale de colisión con un Cilindro : " + other.gameObject.name);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Ball");
    }
}
