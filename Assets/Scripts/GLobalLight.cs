using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLobalLight : MonoBehaviour
{
    // Start is called before the first frame update

    UnityEngine.Rendering.Universal.Light2D light2d;
    float light = 1f;
    void Start()
    {
        light2d = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(light < 0.1f) {
            return;
        }
        light += -0.0001f; // Speed of day light
        light2d.intensity = light;
    }
}
