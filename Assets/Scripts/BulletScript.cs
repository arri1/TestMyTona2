using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : FlyingObject {
    public Transform Master;
    [SerializeField]
    float detonateTime;
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

            b.Hit(Master);
            
            boom();
        }
    }
    protected IEnumerator autoBoom(float t=10)
    {
        yield return new WaitForSeconds(t);
        boom();
    }
    protected void boom()
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
