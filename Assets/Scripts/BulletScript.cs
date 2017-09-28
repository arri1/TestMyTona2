using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : FlyingObject {
    [SerializeField]
    float destroyTime;
	// Use this for initialization
	void Start () {
        GameController.OnRestart += restart;
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
        GameController.OnRestart -= restart;
        StopAllCoroutines();
        Destroy(gameObject);
    }
    protected override void restart()
    {
        boom();
    }

}
