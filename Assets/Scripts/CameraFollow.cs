using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position - Vector3.forward, target.transform.position - Vector3.forward, 1f * Time.deltaTime);
    }
}
