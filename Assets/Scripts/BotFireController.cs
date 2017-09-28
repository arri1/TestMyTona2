using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotFireController : FireController {

	// Use this for initialization
	void Start () {
        StartCoroutine(autoFire());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator autoFire()
    {
        yield return new WaitForSeconds(3);
        fire();
    }
}
