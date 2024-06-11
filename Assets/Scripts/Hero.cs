using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{


    public float steerSpeed = 5f;
    public float moveSpeed = 1f;

    bool isMove = false;
    bool r = false;

    float sideR = 1;

    public bool isTake = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //float steer = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        

        if (isMove)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            GetComponent<Animator>().SetBool("isWalk", true);
        }

        if (r)
        {
            transform.Rotate(0, 0, steerSpeed * sideR);
        }
        
       
    }

    public void MoveOn(float side)
    {
        moveSpeed = side;
        isMove = true;
    }

    public void MoveOff()
    {
        GetComponent<Animator>().SetBool("isWalk", false);
        isMove = false;
    }

    public void CarSteerOn(float side)
    {
        r = true;

        sideR = side;
    }

    public void CarSteerOff()
    {
        r = false;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "cargo" && !isTake)
        {
            coll.transform.SetParent(transform);
            coll.transform.position = transform.position + transform.up * 2;
            isTake = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "snowboard")
        {
            SceneManager.LoadScene("Snowboard");
        }
    }
}
