using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Color32 hasGeneratorColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noGeneratorColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool onGeneratorPlace;
    SpriteRenderer spriteRenderer;

    AudioSource audioSource;

    Rigidbody2D rigidbody2D;

    CanBeMoved canBeMoved;



    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        canBeMoved = GetComponent<CanBeMoved>();
    }

    void LateUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "GeneratorPlace" && !onGeneratorPlace) {
            onGeneratorPlace = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasGeneratorColor;
            audioSource.mute = false;
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            Debug.Log("Generator placed");
            canBeMoved.taken = false;
            canBeMoved.delivered = true;
            Globals.isHeroHasSomethingInHands = false;
            Globals.generatorInstalled = true;
        }
        
    }

    
}
