using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntityBehavior : MonoBehaviour {

    public GameObject damageTrigger;

    public float maxHealth = 3f;
    public float health;
    public float healthDrain = 0f;
    public float SpikeDamage = 1f;
    public bool invincible = false;

    public GameObject killWith;
    public GameObject killParticle;
    public Gradient colorGivenHealth;

    public bool DeathSound = false;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (healthDrain != 0f)
        {
            Damage(healthDrain * Time.deltaTime);
        }
	}

    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Kill();
            return;
        }
        this.GetComponent<SpriteRenderer>().color = colorGivenHealth.Evaluate(health / maxHealth);

        if(damageTrigger != null && amount != 0f)
        {
            damageTrigger.GetComponent<OuputBehavior>().Activate(true);
        }
    }

    public void Kill()
    {
        if(DeathSound)
        {
            SoundControl.instance.PlaySound(SoundControl.Sounds.BossDeath);
        }

        if (killParticle != null)
        {
            killParticle.SetActive(true);
            killParticle.transform.position = this.transform.position;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var spike = collision.gameObject.GetComponent<SpikeBehavior>();
        if (spike != null && spike.primed && !invincible)
        {
            Damage(SpikeDamage);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var spike = collision.GetComponent<SpikeBehavior>();
        if (spike != null && spike.primed && !invincible)
        {
            Damage(SpikeDamage);
            if (!spike.indestructable)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
