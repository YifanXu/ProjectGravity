using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutputModule
{
    void Activate();
}

public class SwitchInput : MonoBehaviour {
    public static List<GameObject> switches;

    public GameObject Target;

    public static GameObject GetClosestSwitch(out float distance)
    {
        distance = 0;
        GameObject closestSoFar = null;
        foreach (GameObject obj in switches)
        {
            float thisDist = Vector3.Distance(obj.transform.position, PlayerInput.Player.transform.position);
            if (thisDist > distance)
            {
                distance = thisDist;
                closestSoFar = obj;
            }
        }

        return closestSoFar;
    }

	// Use this for initialization
	void Start () {
        if(switches == null)
        {
            switches = new List<GameObject>();
        }

        switches.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        Target.GetComponent<OuputBehavior>().Activate();
        
    }
}
