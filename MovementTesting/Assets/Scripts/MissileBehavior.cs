using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {

    public GameObject target;
    public float initialVelocity = 1f;
    public float acceleration = 0.1f;
    public float maxTurningRadius = 1f;
    public float turningChange = 0.5f;
    public float currentTurn = 0f;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y) * initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        float currentEuler =  Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        if (eulerToTarget - currentEuler < 180 && eulerToTarget - currentEuler > 0)
        {
            currentTurn += turningChange;
        }
        else if (eulerToTarget - currentEuler > 180 || eulerToTarget - currentEuler < 0)
        {
            currentTurn -= turningChange;
        }
        if(currentTurn > maxTurningRadius) { currentTurn = maxTurningRadius; }
        else  if(currentTurn < -maxTurningRadius) { currentTurn = -maxTurningRadius; }
        currentEuler += currentTurn;

        this.transform.eulerAngles = new Vector3(0, 0, currentEuler);
        rigid.velocity = new Vector2(Mathf.Cos(currentEuler * Mathf.Deg2Rad) * rigid.velocity.magnitude * accelerationByFrame, Mathf.Sin(currentEuler * Mathf.Deg2Rad) * rigid.velocity.magnitude * accelerationByFrame);
	}

    private float eulerToTarget
    {
        get
        {
            return Mathf.Atan2(target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg % 360;
        }
    }

    private float accelerationByFrame
    {
        get
        {
            return 1f + acceleration * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInput.Die("A missile has hit you with a massive kinetic force. You died before it exploded.");
        }
        else if (collision.tag != "Ghost" && !collision.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
