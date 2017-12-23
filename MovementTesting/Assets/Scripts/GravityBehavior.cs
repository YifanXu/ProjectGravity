using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour {

    public static Vector3 direction = Vector3.down;
    public float speed = 5;
    public static int rotationIndex;
    public int privateIndex;
    public static Vector2[] directions = new Vector2[] { Vector2.down, Vector2.right, Vector2.up, Vector2.left };

    public bool enabled;
    public bool rotateUponChange = false;

	// Use this for initialization
	void Start () {
        this.enabled = true;
        this.privateIndex = rotationIndex;
        Debug.Log(rotationIndex);
	}

    // Update is called once per frame
    void Update() {
        if (enabled)
        {
            this.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
        if (rotationIndex > privateIndex)
        {
            if (rotateUponChange)
            {
                this.transform.Rotate(new Vector3(0, 0, 90));
            }
            this.privateIndex++;
        }
        else if (rotationIndex < privateIndex)
        { 
            if (rotateUponChange)
            {
                this.transform.Rotate(new Vector3(0, 0, -90));
            }
            this.privateIndex--;
        }
        
    }

    public static void UpdateDirection(int rotationIndex, int change)
    {
        GravityBehavior.rotationIndex = rotationIndex;
        direction = directions[((rotationIndex + 4000)% 4)];
    }

    public static Vector2 TranslateDireciton(int index)
    {
        return directions[(index + rotationIndex + 4000) % 4];
    }

    public static void ResetAll()
    {
        rotationIndex = 0;
        direction = Vector2.down;
    }
}
