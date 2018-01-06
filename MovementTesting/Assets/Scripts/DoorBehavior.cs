using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorBehavior : MonoBehaviour, IOutputModule {

    public bool Closed;
    public Material opendMaterial;
    public Material closedMaterial;

	// Use this for initialization
	void Start () {
        if (this.Closed)
        {
            this.GetComponent<SpriteRenderer>().color = closedMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = opendMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = true;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(bool isStart)  
    {
        this.Closed = !this.Closed;
        if (this.Closed)
        {
            this.GetComponent<SpriteRenderer>().color = closedMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = opendMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = true;
            
        }
    }
}
