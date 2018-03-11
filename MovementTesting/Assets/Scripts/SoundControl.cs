using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControl : MonoBehaviour {

    public enum Sounds
    {
        BossDeath,
        Gunshot,
        Laser,
        PlayerDeath,
        WinSound,
        Rocket
    }

    public AudioClip[] clips;
    public static SoundControl instance;
    public bool musicSupressed;

    private AudioSource audio;
    private AudioSource music;

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        audio = GetComponent<AudioSource>();
        audio.loop = false;
        DontDestroyOnLoad(this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
        if(music == null)
        {
            music = MusicControll.instance.GetComponent<AudioSource>();
        }
		if(musicSupressed && !audio.isPlaying)
        {
            music.volume *= 2;
            musicSupressed = false;
        }
	}

    public void PlaySound(Sounds sound)
    {
        if (!musicSupressed)
        {
            musicSupressed = true;
            music.volume /= 2;
        }
        audio.clip = clips[(int)sound];
        audio.Play();
    }

}
