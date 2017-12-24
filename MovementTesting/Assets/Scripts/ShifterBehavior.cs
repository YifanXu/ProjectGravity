using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShifterBehavior : MonoBehaviour {

    public float interval;

    public Sprite activated;
    public Sprite deactivated;

    private float timer;

	// Use this for initialization
	void Start () {
        UpdateSprite();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            timer = 0;
            this.GetComponent<Collider2D>().isTrigger = !this.GetComponent<Collider2D>().isTrigger;
            UpdateSprite();
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
