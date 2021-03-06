﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    /// <summary>
    /// When the player collides with object, the player is given another jump and its momentum is stopped.
    /// </summary>
    /// <param name="other">The other object</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        //var rigidbody = this.GetComponent<Rigidbody2D>();
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = 0;
        if (other.gameObject.tag != "StageProp")
        {
            this.GetComponent<PlayerMove>().RestoreMove();
            this.GetComponent<PlayerMove>().special = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag != "StageProp")
        {
            this.GetComponent<PlayerMove>().RestoreMove();
        }
    }

    /// <summary>
    /// When the player leaves a wall, the player can no longer jump.
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag != "StageProp")
        {
            this.GetComponent<PlayerMove>().canMove = false;
        }
    }
}
