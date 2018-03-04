using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {
    public GameObject target;

    public GameObject bullet;
    public float shootInterval = 3f;
    public float shootStrength;

    public float turnSpeed;

    private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(this.target == null)
        {
            target = PlayerInput.Player;
        }

        this.transform.eulerAngles = this.transform.eulerAngles.z.StandarizeEuler().GetRotation();
        float currentEuler = this.transform.eulerAngles.z;
        float end = targetEuler.StandarizeEuler();
        if ((end - currentEuler < 180 && end - currentEuler > 0) || end - currentEuler < -180)
        {
            currentEuler += turnSpeed;
            if(Mathf.Abs(currentEuler - end) < 10f)
            {
                currentEuler = Mathf.Min(end, currentEuler);
            }
        }
        else if (end - currentEuler > 180 || end - currentEuler < 0)
        {
            currentEuler -= turnSpeed;
            if (Mathf.Abs(currentEuler - end) < 10f)
            {
                currentEuler = Mathf.Max(end, currentEuler);
            }
        }
        this.transform.eulerAngles = currentEuler.GetRotation();

        if (timer >= shootInterval)
        {
            timer = 0f;
            Shoot();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        var newBullet = Instantiate(bullet, this.transform.position, new Quaternion());
        newBullet.GetComponent<Rigidbody2D>().AddForce(this.transform.eulerAngles.z.GetVector() * shootStrength);
        if (newBullet.GetComponent<MissileBehavior>() != null)
        {
            newBullet.GetComponent<MissileBehavior>().target = this.target;
        }

    }

    public float targetEuler
    {
        get
        {
            if(target == null)
            {
                return GetComponentInParent<Transform>().eulerAngles.z;
            }
            else
            {
                return GlobalMethods.Get2DEulerAngle(this.transform.position, target.transform.position);
            }
        }
    }
}
