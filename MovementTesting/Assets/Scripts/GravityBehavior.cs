using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour {

    public static Vector3 direction = Vector3.down;
    public float speed;
    public static int rotationIndex;
    public int privateIndex;
    public static Vector2[] directions = new Vector2[] { Vector2.down, Vector2.right, Vector2.up, Vector2.left };

	// Use this for initialization
	void Start () {
        this.privateIndex = rotationIndex;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        if(rotationIndex > privateIndex)
        {
            this.transform.Rotate(new Vector3(0, 0, 90));
            this.privateIndex++;
        }
        else if(rotationIndex < privateIndex)
        {
            this.transform.Rotate(new Vector3(0, 0, -90));
            this.privateIndex--;
        }
        
    }

    public static void UpdateDirection(int rotationIndex, int change)
    {
        GravityBehavior.rotationIndex = rotationIndex;
        direction = directions[((rotationIndex + 4000)% 4)];
        //Debug.Log(string.Format("Now Accelerating ({0}, {1}) Index: {2}", direction.x, direction.y, rotationIndex%4));
    }
}
