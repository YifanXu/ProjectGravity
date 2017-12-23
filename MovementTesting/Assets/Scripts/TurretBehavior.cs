using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

    public float fireRate;
    public float bulletSpeed;
    public GameObject bullet;
    public GameObject target;

    private float fireTimer;

	// Use this for initialization
	void Start () {
        fireTimer = fireRate;
	}
	
	// Update is called once per frame
	void Update () {
        fireTimer -= Time.deltaTime;
        if(fireTimer <= 0)
        {   
            fireTimer = fireRate;
            var newBullet = GameObject.Instantiate(bullet);
            bullet.transform.position = this.transform.position;
            newBullet.GetComponent<Rigidbody2D>().AddForce(targetDirection.normalized * bulletSpeed);
        }
	}

    Vector2 targetDirection
    {
        get
        {
            return new Vector2(target.transform.position.x - this.transform.position.x, target.transform.position.y - this.transform.position.y);
        }
    }
}
