using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    // [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    // GameObject joystick;

    Rigidbody2D rigidbody2D;

    void Awake() {
        // joystick = GameObject.FindWithTag("Joystick").GetComponent<OnScreenStick>;
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Globals.isCarParked)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);

            // Debug.Log("DDDD: " + joystick.Horizontal);
            

            // float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            // float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            // transform.Rotate(0, 0, -steerAmount);
            // transform.Translate(0, moveAmount, 0);

        } else {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            moveSpeed = boostSpeed;
        }

    }
}
