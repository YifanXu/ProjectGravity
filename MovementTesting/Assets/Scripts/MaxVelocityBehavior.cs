using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxVelocityBehavior : MonoBehaviour {

    public float maxVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((this.GetComponent<Rigidbody2D>().velocity.magnitude) > maxVelocity)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * maxVelocity;
        }
	}
}
