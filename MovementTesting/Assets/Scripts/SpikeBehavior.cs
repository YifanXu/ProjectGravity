using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehavior : MonoBehaviour {

    public string DeathSceneName;
    public float primeTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(primeTimer > 0f)
        {
            primeTimer -= Time.deltaTime;
        }
	}

    public bool primed
    {
        get
        {
            return primeTimer <= 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (object.ReferenceEquals(collision.gameObject, PlayerInput.Player))
        {
            PlayerInput.Die("Penetrated by spikes");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (object.ReferenceEquals(collision.gameObject, PlayerInput.Player))
        {
            PlayerInput.Die("Penetrated by spikes");
        }
    }
}
