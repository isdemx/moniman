using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub : MonoBehaviour
{
    [SerializeField] Color32 hasSubColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool onSubPlace;
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

        if(other.tag == "SubPlace" && !onSubPlace) {
            onSubPlace = true;
            Globals.subsOnPlaceCount++;
            if(Globals.subsOnPlaceCount >= 4) {
                Destroy(other.gameObject, destroyDelay);
                Globals.subsInstalled = true;
            }
            spriteRenderer.color = hasSubColor;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            Debug.Log("Sub placed");
            canBeMoved.taken = false;
            canBeMoved.delivered = true;
            Globals.isHeroHasSomethingInHands = false;
        }
        
    }
}
