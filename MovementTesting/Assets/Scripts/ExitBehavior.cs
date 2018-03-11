using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour, IOutputModule {

    public string SceneName;
    public int thisLevel;
    public bool accessible;

    public Sprite enabledSprite;
    public Sprite disabledSprite;

	// Use this for initialization
	void Start () {
        this.accessible = !accessible;
        this.Activate(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if(accessible && other.GetComponent<PlayerInput>() != null)
        {
            PassLevel();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (accessible && other.GetComponent<PlayerInput>() != null)
        {
            PassLevel();
        }
    }

    public void Activate(bool isActive)
    {
        accessible = !accessible;

        if(accessible)
        {
            this.GetComponent<SpriteRenderer>().sprite = enabledSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = disabledSprite;
        }
    }

    private void PassLevel()
    {
        if (thisLevel >= PlayerPrefs.GetInt("LevelAccessible", 1))
        {
            PlayerPrefs.SetInt("LevelAccessible", thisLevel + 1);
        }
        SwitchInput.ClearCache();
        GravityBehavior.ResetAll();
        MusicControll.instance.LoadLevel(SceneName);
    }
}
