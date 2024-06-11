using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFromElectricity : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.Rendering.Universal.Light2D light2d;

    [SerializeField] float updateSpeed = 1f;
    [SerializeField] Color32 color1 = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 color2 = new Color32(1, 1, 1, 1);

    [SerializeField] Color32 color3 = new Color32(1, 1, 1, 1);

    int count = 1;

    Color32 currentColor;
    
    void Start()
    {
        currentColor = color1;

        light2d = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light2d.intensity = 0f;
        Debug.Log("light2d.color" + light2d.color);
        Debug.Log("currentColor" + currentColor);
        InvokeRepeating("SetColor", 1f, updateSpeed);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.generatorInstalled) {
            light2d.intensity = 2f;
        }
        
        light2d.color = currentColor;
    }

    void SetColor() {
        switch(count) {
            case 1:
                currentColor = color1;
                break;
            case 2:
                currentColor = color2;
                break;
            case 3:
                currentColor = color3;
                break;
        }

        count ++;
        if(count > 3) {
            count = 1;
        }
    }
}
