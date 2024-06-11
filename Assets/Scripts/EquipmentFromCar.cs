using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentFromCar : MonoBehaviour {
    [SerializeField] GameObject thingToFollow;
    bool onParkingPlace;
    Renderer renderer;
    BoxCollider2D boxCollider2d;


    void Start() {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
        boxCollider2d = GetComponent<BoxCollider2D>();
        boxCollider2d.enabled = false;
    }

    void LateUpdate()
    {
        if(!Globals.isCarParked){
            transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
        } else {

            if(!onParkingPlace) {
                onParkingPlace = true;
                boxCollider2d.enabled = true;
                renderer.enabled = true;
                transform.position = thingToFollow.transform.position + new Vector3 (0,0,10);
            }
            
        }
    }
}
