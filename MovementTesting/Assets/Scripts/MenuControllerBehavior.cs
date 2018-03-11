using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerBehavior : MonoBehaviour {

    public Button[] buttons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayScene(string name)
    {
        GravityBehavior.ResetAll();
        SwitchInput.switches = new List<GameObject>();
        MusicControll.instance.LoadLevel(name);
    }
}
