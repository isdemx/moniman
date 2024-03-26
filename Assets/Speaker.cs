using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] Color32 hasSpeakerColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool onSpeakerPlace;
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

        if(other.tag == "SpeakerPlace" && !onSpeakerPlace) {
            onSpeakerPlace = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasSpeakerColor;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            Debug.Log("Speaker placed");
            canBeMoved.taken = false;
            canBeMoved.delivered = true;
            Globals.isHeroHasSomethingInHands = false;

            Globals.speakersOnPlaceCount++;
            if(Globals.speakersOnPlaceCount >= 2) {
                Globals.speakersInstalled = true;
            }
        }
        
    }
}
