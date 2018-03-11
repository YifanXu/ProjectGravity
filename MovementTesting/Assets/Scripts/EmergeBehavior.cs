using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergeBehavior : MonoBehaviour {

    public Gradient colorOverEmergence;
    public float timeLimit;
    private float timer = 0f;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= timeLimit)
        {
            timer += Time.deltaTime;
            sprite.color = colorOverEmergence.Evaluate(timer / timeLimit);
        }
	}
}
