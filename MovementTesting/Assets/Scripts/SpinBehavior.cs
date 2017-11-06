using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBehavior : MonoBehaviour {
    public int rotationIndex;
    public float smallSize;
    public float bigSize;
    //public float lerpFactor;
    //public float SpinInterval;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, -90));
            rotationIndex--;
            GravityBehavior.UpdateDirection(rotationIndex, -1);
            ResizeCamera();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, 90));
            rotationIndex++;
            GravityBehavior.UpdateDirection(rotationIndex, 1);
            ResizeCamera();
        }
        
    }

    public float CurrentRotation
    {
        get
        {
            return this.transform.rotation.z;
        }
    }

    private void ResizeCamera()
    {
        if(this.rotationIndex % 2 == 0)
        {
            this.GetComponent<Camera>().orthographicSize = smallSize;
        }
        else
        {
            this.GetComponent<Camera>().orthographicSize = bigSize;
        }
    }
}
