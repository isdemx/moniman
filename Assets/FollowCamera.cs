using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // This thjngs position camera should be the same as  the cars position
    [SerializeField] GameObject car;
    [SerializeField] GameObject man;
    void LateUpdate()
    {
        
        if(!Globals.isCarParked) {
            transform.position = car.transform.position + new Vector3 (0,0,-100);
        } else {
            transform.position = man.transform.position + new Vector3 (0,0,-100);
        }
        
    }
}
