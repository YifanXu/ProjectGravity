using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutputModule
{
    void Activate();
}

public class SwitchInput : MonoBehaviour {
    public static List<GameObject> switches;

    public Sprite OnSwitch;
    public Sprite OffSwitch;

    public bool activated;

    public GameObject Target1;
    public GameObject Target2;
    public GameObject Target3;

    public static GameObject GetClosestSwitch(out float distance)
    {
        distance = 0;
        GameObject closestSoFar = null;
        foreach (GameObject obj in switches)
        {
            float thisDist = Vector3.Distance(obj.transform.position, PlayerInput.Player.transform.position);
            if (closestSoFar == null || thisDist < distance)
            {
                distance = thisDist;
                closestSoFar = obj;
            }
        }

        return closestSoFar;
    }

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this);
        if(switches == null)
        {
            switches = new List<GameObject>();
        }

        updateSprite();
        switches.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        if(Target1 != null)
        {
            Target1.GetComponent<OuputBehavior>().Activate();
        }
        if (Target2 != null)
        {
            Target2.GetComponent<OuputBehavior>().Activate();
        }
        if (Target3 != null)
        {
            Target3.GetComponent<OuputBehavior>().Activate();
        }
        this.activated = !this.activated;
        updateSprite();
    }

    private void updateSprite()
    {
        if(this.activated)
        {
            this.GetComponent<SpriteRenderer>().sprite = OnSwitch;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = OffSwitch;
        }
    }

    public static void ClearCache()
    {
        switches = new List<GameObject>();
    }
}
