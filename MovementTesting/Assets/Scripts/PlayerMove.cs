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

    public bool ClickMove;

    private static Dictionary<KeyCode, Vector2> moveDict = new Dictionary<KeyCode, Vector2>()
    {
        {KeyCode.UpArrow, new Vector2 (0,1) },
        {KeyCode.DownArrow, new Vector2 (0,-1) },
        {KeyCode.RightArrow, new Vector2 (1,0) },
        {KeyCode.LeftArrow, new Vector2 (-1,0) },
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
        if (!ClickMove)
        {

            Vector2 direction = new Vector2();
            foreach (KeyValuePair<KeyCode, Vector2> pair in moveDict)
            {
                if (Input.GetKeyDown(pair.Key))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2();
                    direction = pair.Value;
                }
            }
            this.GetComponent<Rigidbody2D>().AddForce(direction * speed);

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
