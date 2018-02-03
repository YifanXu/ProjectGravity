using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {
    public float time = 3f;
    private float count = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count > time)
        {
            KillableEntityBehavior killable = this.GetComponent<KillableEntityBehavior>();
            if (killable != null)
            {
                killable.Kill();
                return;
            }
            TriggerOnDeathBehavior trigger = this.GetComponent<TriggerOnDeathBehavior>();
            if (trigger != null)
            {
                trigger.Die();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
	}
}
