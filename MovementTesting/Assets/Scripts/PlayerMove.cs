using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction {
    Up,
    Down,
    Left,
    Right
}

public class PlayerMove : MonoBehaviour {

    public Vector2 direction;
    public bool special;
    public bool ClickMove;

    private static int jumpIndex = 2;
    private static int leftIndex = 3;
    private static int rightIndex = 1;

    public float speed;
    public float jumpForceMultiplier = 2;

    public bool canMove;
    public float jumpCoolDown;
    public float cdTracker = 0f;

    private GameObject cloestTrigger;

	// Use this for initialization
	void Start () {
        this.canMove = true;
	}

    // Update is called once per frame
    void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.Space)&&special)
        {
            this.special = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2();
            
        }
        if (!ClickMove)
        {
            Vector2 netforce = new Vector2();
            if (canMove && Input.GetKeyDown(KeyCode.W))
            {
                netforce += GetDirection(jumpIndex) * jumpForceMultiplier;
            }
            if(Input.GetKey(KeyCode.A))
            {
                netforce += GetDirection(leftIndex);
            }
            if(Input.GetKey(KeyCode.D))
            {
                netforce += GetDirection(rightIndex);
            }
            this.GetComponent<Rigidbody2D>().AddForce(netforce * speed);
        }
        else
        {
            
            if (cdTracker > 0)
            {
                cdTracker -= Time.deltaTime;
            }
            if (canMove && Input.GetMouseButtonUp(0) && cdTracker <= 0)
            {
                canMove = false;
                cdTracker = jumpCoolDown;
                var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 vector = new Vector3(targetPos.x - this.transform.position.x, targetPos.y - this.transform.position.y, this.transform.position.z).normalized;
                this.GetComponent<Rigidbody2D>().AddForce(vector * speed);
            }
        }
    }

    public Vector2 GetDirection (int index)
    {
        return GravityBehavior.directions[(index + GravityBehavior.rotationIndex + 4000) % 4];
    }

    public void RestoreMove()
    {
        this.canMove = true;
    }

    
}
