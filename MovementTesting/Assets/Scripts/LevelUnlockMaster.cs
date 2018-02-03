using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockMaster : MonoBehaviour {

    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        for(int i = levelReached; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
