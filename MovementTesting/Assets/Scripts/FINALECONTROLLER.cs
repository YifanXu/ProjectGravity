using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINALECONTROLLER : MonoBehaviour,IOutputModule {

    public static FINALECONTROLLER instance;
    public float cooldown = 1f;
    private float timer = 0f;

    public GameObject spike;
    public GameObject turret;
    public GameObject[] stages;
    public GameObject[] cannons;
    public GameObject trueBoss;
    public int currentStage;

	// Use this for initialization
	void Start () {
        instance = this;
        currentStage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
	}

    public void Activate(bool IsStart)
    {
        if(!IsStart || timer > 0f)
        {
            return;
        }
        timer = cooldown;
        SwitchInput.ClearCache();
        Destroy(stages[currentStage]);
        if (currentStage <= 3)
        {
            cannons[currentStage].SetActive(true);
        }
        currentStage++;
        stages[currentStage].SetActive(true);
        if(currentStage == 1)
        {
            trueBoss.SetActive(true);
        }
        else if(currentStage == 2)
        {
            turret.GetComponent<TurretBehavior>().bullet = spike;
        }
    }

}
