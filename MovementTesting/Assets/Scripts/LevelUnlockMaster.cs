using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockMaster : MonoBehaviour {

    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
        LoadButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetAll()
    {
        PlayerPrefs.SetInt("LevelAccessible", 1);
        LoadButtons();
    }


    private void LoadButtons()
    {
        int LevelAccessible = PlayerPrefs.GetInt("LevelAccessible", 1);

        for (int i = LevelAccessible; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }
}
