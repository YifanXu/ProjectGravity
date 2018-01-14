using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseBehavior : MonoBehaviour {

    public GameObject target;
    public float pulseTime = 1f;
    public float speed;

    private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer >= pulseTime)
        {
            timer = 0;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.y - this.transform.position.y).normalized * speed);
        }
        timer += Time.deltaTime;
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //PlayerInput.Die("The Rouge Cube has entered your mind, and you are too now a rouge cube.");
        }
    }
}
