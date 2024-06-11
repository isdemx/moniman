using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    AudioSource audioSource;

    void Start() {

        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
    }

    void LateUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "GeneratorPlace") {                      
            audioSource.mute = false;         
            Globals.isHeroHasSomethingInHands = false;
            Globals.generatorInstalled = true;
        }
        
    }

    
}
