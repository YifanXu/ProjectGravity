using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour,IOutputModule {

    private float standardWidth;
    private GameObject target;

    private bool activated = false;
    private bool activationDetection;

    public float spassmStrength = 0.1f;
    public float shootTime = 3f;

    //Countdown Timer
    private float timer;

	// Use this for initialization
	void Start () {
        activated = false;
        standardWidth = this.transform.localScale.y;
        target = GetComponentInParent<BossCannonBehavior>().target;

        Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<SpriteRenderer>().enabled)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, standardWidth * UnityEngine.Random.Range(1f - spassmStrength, 1f + spassmStrength));
        }

        if (timer > 0f && timer <= shootTime)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0f)
        {
            Activate(false);
        }

        //if (activated)
        //{
        //    activationDetection = true;
        //}
        //else if (activationDetection)
        //{
        //    activationDetection = false;
        //    activated = false;
        //}
    }


    public void Activate(bool isStart)
    {
        this.activated = isStart;
        this.GetComponent<SpriteRenderer>().enabled = isStart;

        if(isStart)
        {
            timer = shootTime;
            SwitchInput.ActivateAll();
            GetComponentInParent<BossCannonBehavior>().UpdateSprite();
            target.GetComponent<KillableEntityBehavior>().Damage(1f);
        }
        else
        {
            timer = shootTime + 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && timer < shootTime && timer >= 0f)
        {
            PlayerInput.Die("Burned in own laser");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Colliders cannot be detected this way if two colliders are colliding when the game starts.

        //Debug.Log(activated);
        //if (activated)
        //{
        //    Debug.Log("Laser detect collision");

        //    if (collision == target)
        //    {
        //        target.GetComponent<KillableEntityBehavior>().Damage(1f);
        //    }
        //}
        //if (collision.tag == "Player" && timer < shootTime && timer >= 0f)
        //{
        //    PlayerInput.Die();
        //}
    }
}
