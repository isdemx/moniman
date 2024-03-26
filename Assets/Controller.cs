using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    [SerializeField] Color32 hasControllerColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool onControllerPlace;
    SpriteRenderer spriteRenderer;

    Rigidbody2D rigidbody2D;

    CanBeMoved canBeMoved;



    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        canBeMoved = GetComponent<CanBeMoved>();
    }

    void LateUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "ControllerPlace" && !onControllerPlace) {
            onControllerPlace = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasControllerColor;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            Debug.Log("Controller placed");
            canBeMoved.taken = false;
            canBeMoved.delivered = true;
            Globals.isHeroHasSomethingInHands = false;
            Globals.controllerInstalled = true;
        }
        
    }
}
