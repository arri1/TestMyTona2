using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : FlyingObject
{
    [SerializeField]
    Transform target;
    // Use this for initialization
    void Start () {
        target = GameController.Instance.Player.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 d = transform.position - target.position;
        transform.LookAt(target.position);
        Rigidbody.AddForce(transform.up * forwardSpeed);
        if (Rigidbody.velocity.magnitude > forwardMaxSpeed)
        {
            Rigidbody.velocity = transform.up * forwardMaxSpeed;
        }
       
    }
    protected override void dead()
    {
        Destroy(gameObject);
    }
    IEnumerator autoDestroy()
    {
        yield return new WaitForSeconds(30);
        dead();
    }
}
