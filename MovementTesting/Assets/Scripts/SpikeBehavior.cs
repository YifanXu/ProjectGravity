using System.Collections;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(object.ReferenceEquals(other.gameObject,PlayerInput.Player))
        {
            SceneManager.LoadScene(DeathSceneName);
        }
    }
}
