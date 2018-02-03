using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBehavior : MonoBehaviour, IOutputModule {

    public float speed = 5f;
    public float offSpeed = 0f;
    public bool activated = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + speed);
        }
        else if(offSpeed != 0f)
        {
            this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + offSpeed);
        }
	}

    public void Activate(bool isStart)
    {
        this.activated = !activated;
    }
}
