using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherRigid = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherRigid != null)
        {
            otherRigid.velocity = this.GetComponent<Rigidbody2D>().velocity;
        }
        else
        {
            this.gameObject.StopRigid2D();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var otherRigid = collision.gameObject.GetComponent<Rigidbody2D>();
        if(otherRigid != null)
        {
            otherRigid.velocity = this.GetComponent<Rigidbody2D>().velocity;
            otherRigid.angularVelocity = 0f;
        }
    }
}
