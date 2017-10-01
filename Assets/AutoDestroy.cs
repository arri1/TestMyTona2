using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
	// Use this for initialization
	void Start () {
        StartCoroutine(CheckIfAlive());

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator CheckIfAlive()
    {
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();

        while (true && ps != null)
        {
            yield return new WaitForSeconds(0.5f);
            if (!ps.IsAlive(true))
            {

                    GameObject.Destroy(this.gameObject);

            }
        }
    }
}
