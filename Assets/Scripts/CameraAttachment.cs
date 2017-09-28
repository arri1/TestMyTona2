using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttachment : MonoBehaviour {
    public Transform CameraPoint;
    Vector3 distance;
	// Use this for initialization
	void Start () {
        distance = CameraPoint.position - transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = CameraPoint.position - distance;
	}
}
