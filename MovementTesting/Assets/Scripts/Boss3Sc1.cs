using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Sc1 : MonoBehaviour {
	public float GravityChangeInterval;
	public int GravityDirectionNum;
    public static string GravityCurrentDirection=string.Empty;
	public float Timer=0f;

	//	0 is left 1 is up 2 is right 3 is down

	// Use this for initialization
	void Start () {
		GravityChangeInterval = Random.value * 10f;
		GravityDirectionNum = GlobalMethods.r.Next(4);
        if (GravityDirectionNum == 0)
        {
            GravityCurrentDirection = "left";
        }
        else if (GravityDirectionNum == 1)
        {
            GravityCurrentDirection = "up";
        }
        else if (GravityDirectionNum == 2)
        {
            GravityCurrentDirection = "right";
        }
        else if (GravityDirectionNum == 3) 
        {
            GravityCurrentDirection = "down";
        }
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer >= GravityChangeInterval) {
			GravityBehavior.UpdateDirection (GravityDirectionNum);
             if (GravityDirectionNum == 0)
        {
            GravityCurrentDirection = "left";
        }
        else if (GravityDirectionNum == 1)
        {
            GravityCurrentDirection = "up";
        }
        else if (GravityDirectionNum == 2)
        {
            GravityCurrentDirection = "right";
        }
        else if (GravityDirectionNum == 3) 
        {
            GravityCurrentDirection = "down";
        }
			Timer = 0f;
		}
		
	}
}
