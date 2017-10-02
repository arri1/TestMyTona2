using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    // Use this for initialization
    void Start () {

        GameController.OnPlayFireSound += fire;



    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void fire(AudioSource a)
    {
        StartCoroutine(firePlay(a));
    }

    IEnumerator firePlay(AudioSource a)
    {
        if (a.isPlaying)
            a.Stop();
        a.Play();
        yield return new WaitForSeconds( 2);
        a.Stop();
    }
}
