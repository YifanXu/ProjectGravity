using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;

    private bool canMove = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        /*   ArrowInput
        Vector3 totalVector = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            totalVector.y = speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            totalVector.y = -1* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            totalVector.x = -1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            totalVector.x = speed * Time.deltaTime;
        }

        this.GetComponent<Rigidbody2D>().AddForce(totalVector);
        */
        //MouseInput
        if (canMove && Input.GetMouseButtonUp(0))
        {
            canMove = false;
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 vector = new Vector3(targetPos.x - this.transform.position.x, targetPos.y - this.transform.position.y, this.transform.position.z).normalized;
            this.GetComponent<Rigidbody2D>().AddForce(vector*speed);
        }
    }

    public void RestoreMove()
    {
        this.canMove = true;
    }
}
