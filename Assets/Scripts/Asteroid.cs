using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : BulletScript{


    [SerializeField]
    protected Transform target;
    // Use this for initialization
    void Start () {
        float r = Random.Range(300, 500);
        forwardSpeed = r;

        target = GameController.Instance.Player.transform;
        transform.LookAt(target.position);
        Rigidbody.AddForce(transform.forward * forwardSpeed);
        StartCoroutine(autoBoom(20));
        Rigidbody.angularVelocity = new Vector3(0, 0, Random.Range(0, 100));
        GameController.OnRestart += restart;
    }
	
	// Update is called once per frame
	void Update () {
        if (Rigidbody.velocity.magnitude > forwardMaxSpeed)
        {
            Rigidbody.velocity = Rigidbody.velocity.normalized * forwardMaxSpeed;
        }

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
    public override void Hit(Transform t = null)
    {
        if (t == GameController.Instance.Player.transform)
            GameController.Instance.OnAddPointTrigger(1);
        dead();
    }
}
