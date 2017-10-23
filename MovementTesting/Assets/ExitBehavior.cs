using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehavior : MonoBehaviour, IOutputModule {

    public string SceneName;
    public bool accessible;

    public Sprite enabledSprite;
    public Sprite disabledSprite;

	// Use this for initialization
	void Start () {
        this.accessible = !accessible;
        this.Activate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Exiting");
        if(accessible && other.GetComponent<PlayerInput>() != null)
        {
           SceneManager.LoadScene(SceneName);
        }
    }

    public void Activate()
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
}
