using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bolaBlanca : MonoBehaviour
{

    // FIELDS
    public GameObject palo;
    public Slider powerSlider;
    Rigidbody cuerpoBola;
    public float minVelocity = 0.1F; 
    float force = 0;
    public float maxForce = 30;


    // Start is called before the first frame update
    void Start()
    {
        cuerpoBola = gameObject.GetComponent<Rigidbody>();
        powerSlider.maxValue = maxForce;
    }

    void Update() {
        powerSlider.value = force;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, 0.05f), transform.position.z);
        checkControlls();
        checkVelocity();
        Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, 0);
        Debug.DrawRay(transform.position, transform.forward, Color.white);
    }

    // METODOS PROPIOS

    void hitBall(){
        cuerpoBola.AddForce(transform.forward * force, ForceMode.Impulse);
        force = 0;
    }
    void checkControlls(){
        
        if (Input.GetKey(KeyCode.Space))
        {
            force += 1;
            if(force >= maxForce)
                force = maxForce;
        }
        
        if(Input.GetKeyUp(KeyCode.Space)){
            hitBall();
        }
    }
    void checkVelocity()
    {
        Debug.Log(cuerpoBola.velocity.magnitude);
        if(cuerpoBola.velocity.magnitude <= minVelocity ){
            transform.rotation = Quaternion.Euler(0,palo.transform.rotation.eulerAngles.y,0);
            setPalo();
        } 

    }
    
    void setPalo()
    {
        if(Input.GetKey(KeyCode.Space)){
            
        }else {
            palo.transform.LookAt(transform.position);
            palo.transform.position = new Vector3(
                Mathf.Clamp(palo.transform.position.x, transform.position.x - 0.3F, transform.position.x + 0.3F),
                0.06f,
                Mathf.Clamp(palo.transform.position.z, transform.position.z - 0.3F, transform.position.z + 0.3F));
            if(Input.GetKey(KeyCode.LeftArrow)){
                palo.transform.RotateAround(transform.position,  Vector3.up, 1);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                palo.transform.RotateAround(transform.position,  Vector3.down, 1);
            }
        }
        
    }

    public void restart(){
        SceneManager.LoadScene("Billar");
    }
}
