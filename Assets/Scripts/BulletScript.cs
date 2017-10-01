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
    protected override void boom()
    {
        GameController.OnRestart -= restart;
        StopAllCoroutines();
        AudioSource.PlayClipAtPoint(explisonSound, transform.position,GameController.Instance.SoundVolume);
        GameObject b = Instantiate(boomPrefab, gameObject.transform.position, gameObject.transform.rotation, null);  
        Destroy(gameObject);
    }
    protected override void restart()
    {
        boom();
    }

}
