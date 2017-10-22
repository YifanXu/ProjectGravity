using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        var rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = 0;
        this.GetComponent<PlayerMove>().RestoreMove();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetMouseButton(0))
        {
            this.GetComponent<PlayerMove>().RestoreMove();
        }
    }
}
