using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    public float steerSpeed = 1f;
    public float moveSpeed = 1f;
    
    Rigidbody2D rigidbody2D;

    public bool isMove = false;

    public bool r = false;


    public float currentRotate = 0;
    public float currentSpeed = 0;

    public GameObject apparat;

    public GameObject hero;
    public GameObject camera;

    public GameObject panelCar;
    public GameObject panelHero;
    void Awake() {
       
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //float steer = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        //float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, currentSpeed, 0);
        
        if (isMove)
        {
            currentSpeed += Time.deltaTime * moveSpeed;         
        }

        if (currentSpeed > 0.1 || currentSpeed < -0.1)
        {         
           transform.Rotate(0, 0, currentRotate);        
        }

        currentSpeed *= 0.98f;
        currentRotate *= 0.98f;
    }

    public void MoveOn(float side)
    {
        moveSpeed = side;
        isMove = true;
    }

    public void MoveOff()
    {
        isMove = false;
    }

    public void CarSteerOn(float side)
    {
        r = true;

        currentRotate += steerSpeed * side;
    }

    public void CarSteerOff()
    {
        r = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CarParking")
        {
            hero.SetActive(true);
            apparat.SetActive(true);
            camera.GetComponent<CameraFollow>().target = hero;
            panelCar.SetActive(false);
            panelHero.SetActive(true);
            GetComponent<Driver>().enabled = false;
        }
    }



}
