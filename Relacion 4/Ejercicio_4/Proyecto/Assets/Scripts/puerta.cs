using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public GameObject player;
    public float  distanciaRay = 2f;
    float tDelta = 0;
    
    Vector3 positionCasting;
    Vector3 startDoor;
    Vector3 openedDoor;
    // Start is called before the first frame update
    void Start()
    {
        positionCasting = new Vector3(transform.position.x + -1.5f, transform.position.y + 3f, transform.position.z );

        startDoor = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        openedDoor = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        // LIMITACIONES
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            Mathf.Clamp(transform.rotation.eulerAngles.y,startDoor.y, openedDoor.y),
            transform.rotation.eulerAngles.z
            );
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y,1, 3),
            transform.position.z
            );

        if(gameObject.tag == "Puerta")
        {
            Debug.DrawRay(positionCasting, player.transform.position -  positionCasting);
            if(Physics.Raycast(positionCasting,  player.transform.position - positionCasting, out RaycastHit info, distanciaRay,  ~(1 << 0)))
            {
                if(info.collider.gameObject == player)
                    transform.Rotate(Vector3.up);
                    
            }
            else {
                if(transform.position.y > 1.1f)
                    transform.Rotate(Vector3.down);
            }
        }
        if(gameObject.tag == "Elevador")
        {
            Debug.DrawRay(positionCasting, player.transform.position -  positionCasting);
            if(Physics.Raycast(positionCasting,  player.transform.position - positionCasting, out RaycastHit info, distanciaRay,  ~(1 << 0)))
            {
                if(info.collider.gameObject == player)
                    transform.Translate(Vector3.up);
            }
            else{
                if(transform.rotation.eulerAngles.y > startDoor.y + 1)
                    transform.Translate(Vector3.down);
            }
        }
        
    }
}
