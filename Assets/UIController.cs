using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField]
    GameObject losingMenu;
	// Use this for initialization
	void Start () {
        GameController.OnGameOver += gameOver;
        GameController.OnRestart += restart;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void gameOver()
    {
        losingMenu.SetActive(true);
    }
    void restart()
    {
        losingMenu.SetActive(false);
    }
}
