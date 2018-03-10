using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Sc1 : MonoBehaviour {
	public float GravityChangeInterval;
	public static int GravityDirectionNum;
   
	public float Timer=0f;
	public GameObject[] psObjs;

	//	0 is left 1 is up 2 is right 3 is down

	// Use this for initialization
	void Start () {
		GravityChangeInterval = Random.value * 10f;
		//GravityDirectionNum = GlobalMethods.r.Next(2);
		GravityDirectionNum=0;
		psObjs [0].SetActive (true);
		psObjs [1].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer >= GravityChangeInterval) {
			psObjs [0].SetActive (false);
			psObjs [1].SetActive (false);

			if (GravityDirectionNum == 0) {
				psObjs [0].SetActive (false);
				psObjs [1].SetActive (true);
				GravityBehavior.UpdateDirection (2);
				GravityDirectionNum = 1;
			} else if (GravityDirectionNum == 1) {
				GravityBehavior.UpdateDirection (2);
				psObjs [1].SetActive (false);
				psObjs [0].SetActive (true);
				GravityDirectionNum = 0;
			}

			
			Timer = 0f;
			GravityChangeInterval = Random.value * 10f;

			Debug.Log (GravityDirectionNum);

		}
		
	}
}
