using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingProjectileBehavior : MonoBehaviour {

    public float time = 3f;

	// Use this for initialization
	void Start () {
        this.GetComponent<Collider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            this.GetComponent<Collider2D>().isTrigger = false;
        }
	}
}
