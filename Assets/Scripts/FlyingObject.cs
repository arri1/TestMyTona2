using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour {
    [SerializeField]
    protected GameObject boomPrefab;
    new Rigidbody rigidbody;

    public Rigidbody Rigidbody
    {
        get
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }
            return rigidbody;
        }
    }
    [SerializeField]
    protected float forwardSpeed;
    [SerializeField]
    protected float forwardMaxSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void boom()
    {
        GameObject b = Instantiate(boomPrefab, gameObject.transform.position, gameObject.transform.rotation, null);
    }
    virtual public void Hit(Transform t=null)
    {
        dead();
    }
    virtual protected void dead()
    {

    }
    virtual protected void restart()
    {
        Destroy(gameObject);
    }
}
