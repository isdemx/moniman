using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPoint : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.generatorInstalled && Globals.subsInstalled && Globals.speakersInstalled && Globals.controllerInstalled) {
            audioSource.mute = false;
        }
    }
}
