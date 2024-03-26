using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeMoved : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject man;
    public bool taken = false;
    public bool delivered = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taken == true ) {
            transform.position = man.transform.position + new Vector3 (-2,-2, 10);
        }
        
    }
}
