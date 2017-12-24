using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {

    public GameObject target;
    public float acceleration = 1f;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        rigid.AddForce(new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.y - this.transform.position.y).normalized * acceleration);

        this.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * 180);
	}
}
