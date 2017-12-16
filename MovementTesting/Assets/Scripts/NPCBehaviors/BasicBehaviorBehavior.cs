using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBehaviorBehavior : MonoBehaviour {

    public float gracePeriod = 0.1f;
    public float Velocity;
    public GameObject wallDetector;
    public GameObject edgeDetector;
    public int index;

    private float graceTimer = 0f;

	// Use this for initialization
	void Start () {
        index = 1;
	}
	
	// Update is called once per frame
	void Update () {
        var movement = GravityBehavior.TranslateDireciton(index) * Velocity * Time.deltaTime;
        this.transform.position += new Vector3(movement.x, movement.y, 0);

        if(graceTimer < gracePeriod)
        {
            graceTimer += Time.deltaTime;
        }

        
    }

    public void Flip()
    {
        if (graceTimer < gracePeriod)
        {
            return;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
            index += 2;
            wallDetector.GetComponent<Collider2D>().offset = -wallDetector.GetComponent<Collider2D>().offset;
            edgeDetector.GetComponent<Collider2D>().offset = -edgeDetector.GetComponent<Collider2D>().offset;
            graceTimer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        int index = this.GetComponent<GravityBehavior>().privateIndex;
        this.transform.Rotate(new Vector3(0, 0, 90f * (index % 4)));
    }
}
