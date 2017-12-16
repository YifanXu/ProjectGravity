using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetectorBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Flip (Wall)!");
        if(collision.tag == "Stage")
        {
            GetComponentInParent<BasicBehaviorBehavior>().Flip();
        }
    }
}
