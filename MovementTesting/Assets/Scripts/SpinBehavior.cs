using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBehavior : MonoBehaviour {
    public int rotationIndex;
    public float smallSize = 5f;
    public float bigSize = 5f;
    //public float lerpFactor;
    //public float SpinInterval;

    public float rotationLeft = 0f;
    public float lerpFactor = 0.3f;

    public int initialRotation;

    // Use this for initialization
    void Start () {
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        GravityBehavior.rotationIndex = 0;
        this.transform.Rotate(new Vector3(0, 0, initialRotation));
	}
	
	// Update is called once per frame
	void Update () {

        //MoveCamera
        float rotationAchieved = rotationLeft * lerpFactor;
        this.transform.Rotate(new Vector3(0, 0, rotationAchieved));
        rotationLeft -= rotationAchieved;

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rotationLeft -= 90;
            rotationIndex--;
            GravityBehavior.UpdateDirection(rotationIndex, -1);
            ResizeCamera();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rotationLeft += 90;
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
