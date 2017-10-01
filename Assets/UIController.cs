using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField]
    GameObject losingMenu;
    [SerializeField]
    GameObject winMenu;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject optionsMenu;
    // Use this for initialization
    void Start () {
        GameController.OnGameOver += gameOver;
        GameController.OnRestart += restart;
        GameController.OnGameWin += win;
        GameController.OnPause += pause;
        GameController.OnResume += resume;
        GameController.OnOptionsClick += options;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void win()
    {
        winMenu.SetActive(true);
    }
    void gameOver()
    {
        losingMenu.SetActive(true);
    }
    void restart()
    {
        winMenu.SetActive(false);
        losingMenu.SetActive(false);
    }
    void pause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    void resume()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    void options()
    {

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

}
