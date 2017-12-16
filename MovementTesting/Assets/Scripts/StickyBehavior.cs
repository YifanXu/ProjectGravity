using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : MonoBehaviour {

    public float totalReleaseTime = 1f;

    public float releaseTime = 0f;
    public bool released = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            released = true;
            releaseTime = totalReleaseTime;
        }
        if(released)
        {
            releaseTime -= Time.deltaTime;
            if(releaseTime <= 0)
            {
                released = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ghost")
        {
            return;
        }
        var grav = collision.GetComponent<GravityBehavior>();
        if(grav != null)
        {
            collision.GetComponent<Rigidbody2D>().angularVelocity = 0;
            grav.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            return;
        }
        var grav = other.GetComponent<GravityBehavior>();
        if (grav != null)
        {
            grav.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            return;
        }
        if (!released)
        {
            var otherRigid = other.GetComponent<Rigidbody2D>();
            other.GetComponent<Rigidbody2D>().angularVelocity = 0;
            otherRigid.velocity = new Vector2(0, 0);
        }
        else
        {
            var grav = other.GetComponent<GravityBehavior>();
            if (grav != null)
            {
                grav.enabled = true;
            }
        }
    }
}
