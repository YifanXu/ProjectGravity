using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public Vector2 initialVelocity;
    public float speed;

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().AddForce(initialVelocity.normalized * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInput.Die();
            return;
        }
        if(collision.tag == "Entity")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
