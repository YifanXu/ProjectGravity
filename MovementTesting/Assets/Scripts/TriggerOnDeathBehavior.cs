using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnDeathBehavior : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        if (target != null)
        {
            target.GetComponent<OuputBehavior>().Activate(true);
        }
        Destroy(this.gameObject);
    }
}
