using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{


    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    // [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (!Globals.isHeroHasSomethingInHands)
        {
            if (other.gameObject.tag == "Generator" || other.gameObject.tag == "Speaker" || other.gameObject.tag == "Sub" || other.gameObject.tag == "Controller")
            {

                CanBeMoved canBeMoved = other.gameObject.GetComponent<CanBeMoved>();

                if(!canBeMoved.delivered) {
                    Globals.isHeroHasSomethingInHands = true;
                    canBeMoved.taken = true;
                }
                
            }
        }

    }
}
