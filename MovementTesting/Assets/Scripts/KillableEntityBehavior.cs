using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntityBehavior : MonoBehaviour {

    public float maxHealth = 3f;
    private float health;

    public GameObject killWith;
    public Color dyingColor = new Color(255,0,0);

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Kill();
            return;
        }
        Color current = new Color(0,0,0,255);
        float hpPercent = 1f - health / maxHealth;
        current.r = (255 - (255 - dyingColor.r) * (hpPercent)) / 255;
        current.g = (255 - (255 - dyingColor.g) * (hpPercent)) / 255;
        current.b = (255 - (255 - dyingColor.b) * (hpPercent)) / 255;
        Debug.Log(string.Format("{0} was damaged with {1} health, {2} remaining. Color = ({3},{4},{5},{6}", this.gameObject.name, amount, health,current.r,current.g,current.b,current.a));
        this.GetComponent<SpriteRenderer>().color = current;

        //var behaviorInParent = GetComponentInParent<KillableEntityBehavior>();
        //if (behaviorInParent != null)
        //{
        //    behaviorInParent.Damage(amount);
        //}
    }

    public void Kill()
    {
        if (killWith != null)
        {
            Destroy(killWith);
        }
        var deathScript = this.GetComponent<TriggerOnDeathBehavior>();
        if(deathScript != null)
        {
            deathScript.Die();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
