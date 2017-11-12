using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private static Dictionary<KeyCode, int> moveDict = new Dictionary<KeyCode, int>()
    {
        {KeyCode.A, 0},
        {KeyCode.W, 1},
        {KeyCode.D, 2 },
        {KeyCode.S, 3 },
    };

    private static Dictionary<int, Vector2> outputDict = new Dictionary<int, Vector2>()
    {
        {0, Vector2.left},
        {1, Vector2.up },
        {2,Vector2.right },
        {3, Vector2.down },
    };

    public float speed;

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
            if (canMove)
            {
                Vector2 direction = new Vector2();
                foreach (KeyValuePair<KeyCode, int> pair in moveDict)
                {
                    if (Input.GetKeyDown(pair.Key))
                    {
                        direction += outputDict[(pair.Value - GravityBehavior.rotationIndex + 1000) % 4].normalized;
                    }
                }
                this.GetComponent<Rigidbody2D>().AddForce(direction * speed * Time.deltaTime);
            }   
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

    

    public void RestoreMove()
    {
        this.canMove = true;
    }
}
