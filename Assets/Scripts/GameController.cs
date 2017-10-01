using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    AudioSource music;
    [SerializeField]
    public float SoundVolume
    {
        get
        {
            
    
            return PlayerPrefs.GetFloat("SoundVolume", 1);
        }
        set
        {
            PlayerPrefs.SetFloat("SoundVolume", value);
        }
    }
    [SerializeField]
    public float MusicVolume
    {
        get
        {
            
            
            return PlayerPrefs.GetFloat("MusicVolume", 1); ;
        }
        set
        {
            music.Stop();
            PlayerPrefs.SetFloat("MusicVolume", value); ;
            music.volume = value;
            music.Play();
        }
    }
    public enum GameStatusEnum
    {
        Play,
        Lose,
        Win,
        Pause
    }
    public GameStatusEnum GameStatus=GameStatusEnum.Play;
    #region Events and Delegates 
    public delegate void MoveRight();
    public static event MoveRight OnMoveRight;
    public delegate void MoveLeft();  
    public static event MoveLeft OnMoveLeft;
    public delegate void MoveForward();
    public static event MoveForward OnMoveForward;
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public delegate void GameWin();
    public static event GameWin OnGameWin;
    public delegate void Pause();
    public static event Pause OnPause;
    public delegate void Options();
    public static event Options OnOptionsClick;
    public delegate void Resume();
    public static event Resume OnResume;
    public delegate void Restart();
    public static event Restart OnRestart;
    public delegate void AddPoint(int p);
    public static event AddPoint OnAddPoint;
    public delegate void PlayFireSound(AudioSource a);
    public static event PlayFireSound OnPlayFireSound;

    #endregion
    #region Triggers
    public void OnPlayFireSoundTrigger(AudioSource a)
    {
        if (OnPlayFireSound != null)
            OnPlayFireSound(a);
    }
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
        GameStatus = GameStatusEnum.Lose;
        Time.timeScale = 0;
    }
    public void OnRestartTrigger()
    {
        
        if (OnRestart != null)
            OnRestart();
        GameStatus = GameStatusEnum.Play;
        Time.timeScale = 1;
    }
    public void OnAddPointTrigger(int p)
    {
        if (OnAddPoint != null)
            OnAddPoint(p);
    }
    public void OnGameWinTrigger()
    {
        
        if (OnGameWin != null)
            OnGameWin();
        GameStatus = GameStatusEnum.Win;
        Time.timeScale = 0;
    }
    public void OnPauseTrigger()
    {
        
        if (OnPause != null)
            OnPause();
        Time.timeScale = 0;
        GameStatus = GameStatusEnum.Pause;

    }
    public void OnResumeTrigger()
    {

        if (OnResume != null)
            OnResume();
        Time.timeScale = 1;
        GameStatus = GameStatusEnum.Play;
    }
    public void OnOptionsClickTrigger()
    {

        if (OnOptionsClick != null)
            OnOptionsClick();
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
        music.volume =MusicVolume;
        music.time = (Random.Range(0, music.clip.length));
        music.Play();

    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (GameStatus)
            {
                case GameStatusEnum.Pause:
                    OnResumeTrigger();
                    break;
                case GameStatusEnum.Play:
                    OnPauseTrigger();
                    break;
            }
               
        }
	}
}
