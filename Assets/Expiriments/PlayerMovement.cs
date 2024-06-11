using Fusion;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    //private CharacterController _controller;

    public float PlayerSpeed = 10f;
    
    public string playerName = "None";

    public GameObject myCamera;

    public float steerSpeed = 5f;
    public float moveSpeed = 1f;

    bool isMove = false;
    bool r = false;

    float sideR = 1;

    public bool isTake = false;

    public bool isRotateL, isRotateR;
    public bool ismoveF, ismoveB;


    private void Awake()
    {
        myCamera = GameObject.Find("Camera");
        myCamera.GetComponent<CameraFollow>().target = gameObject;
    }

    public override void FixedUpdateNetwork()
    {
        // Only move own player and not every other player. Each player controls its own player object.
        if (HasStateAuthority == false)
        {
            return;
        }
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Runner.DeltaTime * PlayerSpeed;
        float move = Input.GetAxis("Vertical") * Runner.DeltaTime * PlayerSpeed;
        float rotate = Input.GetAxis("Horizontal") * -4;

        // _controller.Move(move);

        if (move != 0 || rotate != 0)
        {
                                  
            transform.Rotate(0, 0, rotate);
            transform.Translate(0, move, 0);
        }
        /*
        if (move != 0)
        {
            GetComponent<Animator>().SetBool("isWalk", true);

        } else
        {
            GetComponent<Animator>().SetBool("isWalk", false);
        }
        */
        if (ismoveF)
        {
            transform.Translate(0, Runner.DeltaTime * PlayerSpeed, 0);
            GetComponent<Animator>().SetBool("isWalk", true);
        }
        
        if (isRotateL)
        {
            transform.Rotate(0, 0, -4);
        }

        if (isRotateR)
        {
            transform.Rotate(0, 0, 4);
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

    public void WalkOn()
    {
        ismoveF = true;
    }

    public void WalkOff()
    {
        ismoveF = false;
        GetComponent<Animator>().SetBool("isWalk", false);
    }

    public void TurnLeftOn()
    {
        isRotateL = true;
    }

    public void TurnLeftOff()
    {
        isRotateL = false;
    }

    public void TurnRightOn()
    {
        isRotateR = true;
    }

    public void TurnRightOff()
    {
        isRotateR = false;
    }


}