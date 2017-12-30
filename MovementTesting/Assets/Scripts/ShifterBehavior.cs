using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShifterBehavior : MonoBehaviour {

    public float activationDelay;

    public Sprite activated;
    public Sprite deactivated;

    public float timer;

	// Use this for initialization
	void Start () {
        UpdateSprite();
        timer = activationDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if(timer < 0f)
        {
            this.GetComponent<Collider2D>().isTrigger = !this.GetComponent<Collider2D>().isTrigger;
            UpdateSprite();
            timer = activationDelay;
        }
        else if(timer < activationDelay)
        {
            timer -= Time.deltaTime;
        }
	}

    public void Activate()
    {
        if (timer < activationDelay)
        {
            Debug.Log("Cancel Activation");
            timer = activationDelay;
        }
        else
        {
            Debug.Log("Activation");
            timer -= Time.deltaTime;
        }
    }

    public void UpdateSprite()
    {
        if(this.GetComponent<Collider2D>().isTrigger)
        {
            this.GetComponent<SpriteRenderer>().sprite = deactivated;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = activated;
        }
    }
}
