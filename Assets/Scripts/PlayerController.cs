﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FlyingObject
{
    [SerializeField]
    bool deadKey=false;
    enum moveStatusEnum
    {
        Hold,
        Right,
        Left
    }
    moveStatusEnum moveStatus = moveStatusEnum.Hold;
    
    [SerializeField]
    float rotationSpeed;

    // Use this for initialization
    void Start ()
    {
        GameController.OnRestart += restart;


    }

    // Update is called once per frame
    void Update ()
    {
        if (!deadKey)
        {

            if (Input.GetKey(KeyCode.A))
            {
                moveLeft();
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    moveRight();
                }
                else
                    moveForward();

            }
            if (Rigidbody.velocity.magnitude > forwardMaxSpeed)
            {
                Rigidbody.velocity = Rigidbody.transform.up * forwardMaxSpeed;
            }
            Rigidbody.AddForce(Rigidbody.transform.up * forwardSpeed);
        }


    }
    void moveLeft()
    {
        
        Rigidbody.angularVelocity=new Vector3(0,0, -rotationSpeed * 5);
        GameController.Instance.OnMoveLeftTrigger();
    }
    void moveRight()
    {
        Rigidbody.angularVelocity = new Vector3(0,0, rotationSpeed * 5);
        GameController.Instance.OnMoveRightTrigger();
    }
    void moveForward()
    {
        Rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
    protected override void dead()
    {
        GameController.Instance.OnGameOverTrigger();
        deadKey = true;
        Rigidbody.velocity = Vector3.zero;
    }
    protected override void restart()
    {
        deadKey = false;
    }
}
