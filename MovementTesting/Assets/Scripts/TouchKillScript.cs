using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchKillScript : MonoBehaviour {

    bool playerOnly = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerOnly && collision.gameObject == PlayerInput.Player)
        {
            PlayerInput.Die("Hit by a orange pedestrian.");
        }
        else if(!playerOnly && collision.gameObject.GetComponent<KillableEntityBehavior>() != null)
        {
            collision.gameObject.GetComponent<KillableEntityBehavior>().Damage(1);
        }
    }
}
