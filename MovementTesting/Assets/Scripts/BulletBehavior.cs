using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public Vector2 initialVelocity;
    public float speed;

    public float gracePeriod = 1f;

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().AddForce(initialVelocity.normalized * speed);
	}
	
	// Update is called once per frame
	void Update () {
        if (gracePeriod >= 0)
        {
            gracePeriod -= Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gracePeriod <= 0)
        {
            if (collision.tag == "Player")
            {
                PlayerInput.Die("Please try to not swallow a bullet next time...");
                return;
            }
            if (collision.tag == "Entity")
            {

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    
}
