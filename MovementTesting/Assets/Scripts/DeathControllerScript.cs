using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    
public class DeathControllerScript : MonoBehaviour {

    private string level;
    private static int deathCount = 0;
    public string startingLevel;
    public string deathMessage;

    public KeyCode reviveKey;
    public KeyCode resetKey;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        level = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("DeathScene");
        SwitchInput.ClearCache();
        GravityBehavior.ResetAll();
        deathCount++;
    }
	
	// Update is called once per frame
	void Update () {

        if(SceneManager.GetActiveScene().name == "DeathScene")
        {
            MessageBehavior.deathMessage.GetComponent<Text>().text = "Death Analysis: " + this.deathMessage;
            MessageBehavior.deathCount.GetComponent<Text>().text = string.Format("Deaths: {0} (so far)", deathCount);
        }

		if(Input.GetKeyDown(reviveKey))
        {
            MusicControll.instance.LoadLevel(level);
        }
        else if(Input.GetKeyDown(resetKey))
        {
            MusicControll.instance.LoadLevel(startingLevel);
        }
        else
        {
            return;
        }
        Destroy(this.gameObject);
	}
}
