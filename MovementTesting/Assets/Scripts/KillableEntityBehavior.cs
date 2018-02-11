using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntityBehavior : MonoBehaviour {

    public float maxHealth = 3f;
    private float health;
    public float healthDrain = 0f;
    public float SpikeDamage = 1f;
    public bool invincible = false;

    public GameObject killWith;
    public GameObject killParticle;
    public Gradient colorGivenHealth;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Damage(healthDrain * Time.deltaTime);
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

        //var behaviorInParent = GetComponentInParent<KillableEntityBehavior>();
        //if (behaviorInParent != null)
        //{
        //    behaviorInParent.Damage(amount);
        //}
    }

    public void Kill()
    {
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
            this.health -= SpikeDamage;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var spike = collision.GetComponent<SpikeBehavior>();
        if (spike != null && spike.primed && !invincible)
        {
            this.health -= SpikeDamage;
            Destroy(collision.gameObject);
        }
    }
}
