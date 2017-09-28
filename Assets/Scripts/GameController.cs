using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    #region Events and Delegates 
    public delegate void MoveRight();
    public static event MoveRight OnMoveRight;
    public delegate void MoveLeft();  
    public static event MoveLeft OnMoveLeft;
    public delegate void MoveForward();
    public static event MoveForward OnMoveForward;
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public delegate void Restart();
    public static event Restart OnRestart;
    #endregion
    #region Triggers
    public void OnMoveRightTrigger()
    {
        if (OnMoveRight != null)
            OnMoveRight();
    }
    public void OnMoveLeftTrigger()
    {
        if (OnMoveLeft != null)
            OnMoveLeft();
    }
    public void OnGameOverTrigger()
    {
        if (OnGameOver != null)
            OnGameOver();
    }
    public void OnRestartTrigger()
    {
        if (OnRestart != null)
            OnRestart();
    }
    #endregion
    [SerializeField]
    PlayerController player;
    public PlayerController Player
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<PlayerController>();
            return player;
        }
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	// Update is called once per frame
	void Update ()
    {
        
	}
}
