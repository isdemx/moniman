using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DriveWIthButton : Button
{
    [SerializeField] string buttonDir = "up";
    // Button is Pressed
    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Presssed");
        base.OnPointerDown(eventData);
       

        turnPressOnOff(true);
        
    }

    // Button is released
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        
        turnPressOnOff(false);

    }

    private void turnPressOnOff(bool target) {
        switch(buttonDir) {
            case "up":
                Globals.buttonUp = target;
                break;
            case "down":
                Globals.buttonDown = target;
                break;
            case "left":
                Globals.buttonLeft = target;
                break;
            case "right":
                Globals.buttonRight = target;
                break;
        }
    }
}
