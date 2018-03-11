using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour {

    public GameObject deathController = null;
    public static GameObject Player;
    public string MenuScene = "LevelSelect";

    public float TriggerMaxDistance;

    // Use this for initialization
    void Start () {
        if (Player != null)
        {
            Destroy(Player.gameObject);
        }
        Player = this.gameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyUp(KeyCode.E))
        {
            float dist;
            var obj = SwitchInput.GetClosestSwitch(out dist);
            if (obj == null || dist > TriggerMaxDistance)
            {
                //I like debug lines!
            }
            else
            {
                obj.GetComponent<SwitchInput>().Trigger();
            }
        } 

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            MusicControll.instance.LoadLevel(MenuScene);
        }
	}

    public static void Die(string message)
    {
        SoundControl.instance.PlaySound(SoundControl.Sounds.PlayerDeath);
        Boss3Sc1.GravityDirectionNum = 0;
        var death = Instantiate(Player.GetComponent<PlayerInput>().deathController);
        death.GetComponent<DeathControllerScript>().deathMessage = message;
    }
}
