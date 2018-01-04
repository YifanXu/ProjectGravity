﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehavior : MonoBehaviour {

    public string DeathSceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (object.ReferenceEquals(collision.gameObject, PlayerInput.Player))
        {
            PlayerInput.Die("You just got some nice little holes on your body with spikes in them!");
        }
    }
}
