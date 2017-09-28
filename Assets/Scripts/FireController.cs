using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform barrelTransform;
    [SerializeField]
    float power;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected void fire()
    {
        GameObject b = Instantiate(bulletPrefab,barrelTransform.position,barrelTransform.rotation,null);
        Rigidbody r = b.GetComponent<Rigidbody>();
        r.AddForce(barrelTransform.up*power);

    }
}
