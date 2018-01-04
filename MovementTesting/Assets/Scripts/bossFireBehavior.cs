using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFireBehavior : MonoBehaviour, IOutputModule {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(bool isStart)
    {
        if (isStart)
        {
            GetComponentInParent<BossCannonBehavior>().AttemptFire();
        }
    }
}