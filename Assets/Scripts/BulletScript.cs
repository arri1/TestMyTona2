using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    [SerializeField]
    float destroyTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(autoBoom());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        FlyingObject b = collision.gameObject.GetComponent<FlyingObject>();
        if (b != null)
        {

            b.Hit();
            StopAllCoroutines();
            boom();
        }
    }
    IEnumerator autoBoom()
    {
        yield return new WaitForSeconds(10);
        boom();
    }
    void boom()
    {
        Destroy(gameObject);
    }
}
