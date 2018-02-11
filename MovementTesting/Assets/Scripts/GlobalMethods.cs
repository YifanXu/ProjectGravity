using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GlobalMethods
{
	public static System.Random r = new System.Random ();
    public static Vector2 ToVector2 (this Vector3 original)
    {
        return new Vector2(original.x, original.y);
    }

    public static Vector3 ToVector3(this Vector2 original)
    {
        return new Vector3(original.x, original.y, 0);
    }

    public static Vector2 GetVector (this float theta)
    {
        return new Vector2(Mathf.Cos(theta * Mathf.Deg2Rad), Mathf.Sin(theta * Mathf.Deg2Rad));
    }

    public static float StandarizeEuler (this float euler)
    {
        if (euler > 360)
        {
            return euler % 360;
        }
        else if (euler < 0)
        {
            return euler + 360;
        }
        return euler;
    }

    public static Vector3 GetRotation (this float z)
    {
        return new Vector3(0, 0, z);
    }

    public static void StopRigid2D(this GameObject obj)
    {
        var rigid = obj.GetComponent<Rigidbody2D>();
        if(rigid != null)
        {
            rigid.velocity = new Vector2();
            rigid.angularVelocity = 0;
        }
    }

    public static float Get2DEulerAngle (Vector3 origin, Vector3 target)
    {
        return Mathf.Atan2(target.y - origin.y, target.x - origin.x) * Mathf.Rad2Deg;
    }
    public static float Get2DEulerAngle (Vector2 origin, Vector2 target)
    {
        return Mathf.Atan2(target.y - origin.y, target.x - origin.x) * Mathf.Rad2Deg;
    }
    public static Vector2 GetVectorFromTheta (float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
    }



    public static Vector3 MousePoint
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
