using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnDeathBehavior : MonoBehaviour {

    public GameObject target;

    public GameObject damageTarget;
    public float damage = 1f;

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

        if(damageTarget != null)
        {
            damageTarget.GetComponent<KillableEntityBehavior>().Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
