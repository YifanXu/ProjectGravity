using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {
    public static List<GameObject> switches;

    public float extention;
    private float extentionCount = -100;

    public Sprite unpressedButton;
    public Sprite pressedButton;

    public GameObject Target1;
    public GameObject Target2;
    public GameObject Target3;

    // Use this for initialization
    void Start () {
        extentionCount = -100;
        this.GetComponent<SpriteRenderer>().sprite = unpressedButton;
    }

    // Update is called once per frame
    void Update () {
		if(extentionCount != -100 && extentionCount <= 0)
        {
            Trigger(false);
            extentionCount = -100;
            this.GetComponent<SpriteRenderer>().sprite = unpressedButton;
        }
        else if(extentionCount > 0)
        {
            extentionCount -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        
        if (this.extentionCount == -100)
        {
            Trigger(true);
        }
        this.extentionCount = -100;
        this.GetComponent<SpriteRenderer>().sprite = pressedButton;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        this.extentionCount = -100f;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        extentionCount = extention;
    }

    public void Trigger(bool isStart)
    {
        if (Target1 != null)
        {
            Target1.GetComponent<OuputBehavior>().Activate(isStart);
        }
        if (Target2 != null)
        {
            Target2.GetComponent<OuputBehavior>().Activate(isStart);
        }
        if (Target3 != null)
        {
            Target3.GetComponent<OuputBehavior>().Activate(isStart);
        }
    }
}
