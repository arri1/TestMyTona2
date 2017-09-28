using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FlyingObject
{
    [SerializeField]
    int points = 0;
    [SerializeField]
    int pointsForWin;


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
        PlayerPrefs.SetInt("Level",0);
        GameController.OnRestart += restart;
        GameController.OnAddPoint += addPoint;


    }

    // Update is called once per frame
    void Update ()
    {
        if (GameController.Instance.GameStatus==GameController.GameStatusEnum.Play)
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
        if (GameController.Instance.GameStatus == GameController.GameStatusEnum.Play)
        {
            GameController.Instance.OnGameOverTrigger();
            Rigidbody.velocity = Vector3.zero;
        }
    }
    protected override void restart()
    {
        pointsForWin = 5 + PlayerPrefs.GetInt("Level") * 10;
        points = 0;
    }
    void win()
    {
        if (GameController.Instance.GameStatus == GameController.GameStatusEnum.Play)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            GameController.Instance.OnGameWinTrigger();
        }
    }
    void addPoint(int p)
    {
        if (GameController.Instance.GameStatus == GameController.GameStatusEnum.Play)
        {
            points += p;
            if (pointsForWin < points)
                win();
        }

    }
}
