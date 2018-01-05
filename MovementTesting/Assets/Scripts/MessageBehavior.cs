using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageType
{
    deathMessage,
    deathCount
}

public class MessageBehavior : MonoBehaviour {

    public static GameObject deathMessage;
    public static GameObject deathCount;

    public MessageType messageType;

	// Use this for initialization
	void Start () {
        switch(messageType)
        {
            case MessageType.deathCount:
                deathCount = this.gameObject;
                return;
            case MessageType.deathMessage:
                deathMessage = this.gameObject;
                return;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
