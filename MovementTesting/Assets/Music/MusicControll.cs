 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicControll : MonoBehaviour {

    int currentTrack = -1;

    public static MusicControll instance;
    public string DeathScene;
    public string[] levelNames;
    public AudioClip[] specialClips;
    public AudioClip[] normalClips;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        audio = this.GetComponent<AudioSource>();
        audio.Play();
        audio.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying)
        {
            audio.clip = normalClips[GlobalMethods.r.Next(3)];
            audio.Play();
            audio.loop = false;
        }
	}

    public void LoadLevel(string LevelName)
    {
        for(int i = 0; i < levelNames.Length; i++)
        {
            if(LevelName == levelNames[i])
            {
                audio.Stop();
                audio.clip = specialClips[i];
                audio.Play();
                audio.loop = true;
                SceneManager.LoadScene(LevelName);
                return;
            }
        }
        if(LevelName != DeathScene && audio.loop)
        {
            int newTrack;
            do
            {
                newTrack = GlobalMethods.r.Next(3);
            } while (newTrack == currentTrack);

            currentTrack = newTrack;

            audio.clip = normalClips[currentTrack];
            audio.Stop();
            audio.Play();
            audio.loop = false;
        }

        SceneManager.LoadScene(LevelName);
    }
}
