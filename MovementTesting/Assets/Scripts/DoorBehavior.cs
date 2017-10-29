using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorBehavior : MonoBehaviour, IOutputModule {

    public bool Closed;
    public Material opendMaterial;
    public Material closedMaterial;

	// Use this for initialization
	void Start () {
        this.Closed = !this.Closed;
        this.Activate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()  
    {
        if (this.Closed)
        {
            this.GetComponent<SpriteRenderer>().color = opendMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = closedMaterial.color;
            this.GetComponent<Collider2D>().isTrigger = false;
        }
        this.Closed = !this.Closed;
    }
}
