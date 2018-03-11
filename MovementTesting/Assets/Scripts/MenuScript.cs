using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public GameObject settings;
    public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LvlSelect()
    {
        MusicControll.instance.LoadLevel("LevelSelect");
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeInHierarchy);
    }

    public void Credits()
    {
        credits.SetActive(!credits.activeInHierarchy);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
