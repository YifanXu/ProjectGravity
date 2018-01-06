using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonBehavior : MonoBehaviour, IOutputModule
{
    public float lerpFactor;

    public float contractedPosition;
    public float extendedPosition;
    private Vector3 contractedVector;
    private Vector3 extendedVector;

    public GameObject Base;
    public GameObject rod;
    public GameObject head;

    public bool activated;

    // Use this for initialization
    void Start()
    {
        contractedVector = new Vector3(0, contractedPosition);
        extendedVector = new Vector3(0, extendedPosition);
        Vector3 headPos;
        if (activated)
        {
            headPos = extendedVector;
        }
        else
        {
            headPos = contractedVector;
        }
        head.transform.localPosition = headPos;
    }

    // Update is called once per frame
    void Update()
    {
        //Head Movements
        head.transform.rotation = new Quaternion(0, 0, 0, 0);
        if(activated)
        {
            head.transform.localPosition = Vector3.Lerp(head.transform.localPosition, extendedVector, lerpFactor);
        }
        else
        {
            head.transform.localPosition = Vector3.Lerp(head.transform.localPosition, contractedVector, lerpFactor);
        }

        //Rod Movements
        Vector3 basePos = Base.transform.localPosition;
        Vector3 headPos = head.transform.localPosition;
        rod.transform.localPosition = new Vector3(basePos.x, (basePos.y + headPos.y) / 2);
        rod.transform.localScale = new Vector3(rod.transform.localScale.x, Mathf.Abs(basePos.y - headPos.y) - 0.25f, 1);
    }

    public void Activate(bool isStart)
    {
        this.activated = !activated;
    }
}
