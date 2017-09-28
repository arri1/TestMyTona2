using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : FireController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.GameStatus == GameController.GameStatusEnum.Play)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                fire();
        }

    }
}
