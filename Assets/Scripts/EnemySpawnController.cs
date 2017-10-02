using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    [SerializeField]
    GameObject spawningPrefab;
    [SerializeField]
    float respawnTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(spawn());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3);
        GameObject o = Instantiate(spawningPrefab, transform.position, transform.rotation, null);
        StartCoroutine(spawn());

    }
}
