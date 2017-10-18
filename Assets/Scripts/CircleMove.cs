using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour {
    [SerializeField]
    Transform center;
    
    float radius;
    float alpha=0;
    // Use this for initialization
    void Start ()
    {
        radius = (center.position - transform.position).magnitude;
		
	}
	
	// Update is called once per frame
	void Update () {
        alpha += Time.deltaTime;
        transform.position = new Vector3(radius * Mathf.Cos(alpha) + center.position.x, radius * Mathf.Sin(alpha) + center.position.y);
	}
}
