﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuputBehavior : MonoBehaviour
{
    
    public Component component;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate()
    {
        if(component is IOutputModule)
        {
            ((IOutputModule)component).Activate();
        }
    }
}
