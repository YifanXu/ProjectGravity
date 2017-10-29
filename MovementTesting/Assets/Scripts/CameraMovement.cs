using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float lerpFactor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = new Vector3(PlayerInput.Player.transform.position.x, PlayerInput.Player.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, playerPos, lerpFactor);
	}
}
