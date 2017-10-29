using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static GameObject Player;

    public float TriggerMaxDistance;

    // Use this for initialization
    void Start () {
        if (Player != null)
        {
            Destroy(Player.gameObject);
        }
        Player = this.gameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyUp(KeyCode.E))
        {
            float dist;
            var obj = SwitchInput.GetClosestSwitch(out dist);
            if (obj == null || dist > TriggerMaxDistance)
            {
                Debug.Log("Nothing Found");
            }
            else
            {
                Debug.Log(obj.name);
                obj.GetComponent<SwitchInput>().Trigger();
            }
        } 
	}
}
