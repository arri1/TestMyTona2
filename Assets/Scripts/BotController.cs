using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : FlyingObject
{
    [SerializeField]
    protected Transform target;
    // Use this for initialization
    void Start () {
        GameController.OnRestart += restart;
        target = GameController.Instance.Player.transform;
        StartCoroutine(autoDestroy());
       
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 d = transform.position - target.position;
        transform.LookAt(target.position);
        Rigidbody.AddForce(transform.forward * forwardSpeed);
        if (Rigidbody.velocity.magnitude > forwardMaxSpeed)
        {
            Rigidbody.velocity = transform.forward * forwardMaxSpeed;
        }
       
    }
    public override void Hit(Transform t = null)
    {
        if (t == GameController.Instance.Player.transform)
            GameController.Instance.OnAddPointTrigger(2);
        dead();
    }
    protected override void dead()
    {
        StopAllCoroutines();
        GameController.OnRestart -= restart;
        Destroy(gameObject);
    }
    protected IEnumerator autoDestroy()
    {
        yield return new WaitForSeconds(30);
        dead();
    }
    protected override void restart()
    {
        dead();
    }
}
