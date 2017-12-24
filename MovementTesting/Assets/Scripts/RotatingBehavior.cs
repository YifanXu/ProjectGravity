using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBehavior : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + speed);
	}
}
