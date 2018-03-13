using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustingRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float translation = GravityBehavior.rotationIndex * 90 + 180;
        this.transform.Rotate(new Vector3(0,0,translation));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
