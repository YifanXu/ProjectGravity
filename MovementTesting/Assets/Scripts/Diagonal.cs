using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagonal : MonoBehaviour {
	public float SpikeTravelSpeed;
	public float SpikeDirection;
	public float LeftRight;
	public float TravelTime;
	public float FiringInterval;
	public float Timer=0f;
	public float OriginalPosX;
	public float OriginalPosY;
	public float OriginaPosZ;
	public Vector3 Rotation;


	bool fired=false;
	Rigidbody2D MyRigid;
	// Use this for initialization
	void Start () {
		FiringInterval = Random.value * 10f;
		MyRigid = GetComponent<Rigidbody2D> ();
		OriginalPosX = gameObject.transform.position.x;
		OriginalPosY = gameObject.transform.position.y;
		OriginaPosZ = gameObject.transform.position.z;
		Rotation = new Vector3 (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);


	}

	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (fired==false&&Timer >= FiringInterval) {
			MyRigid.AddForce (new Vector2 (SpikeDirection, LeftRight) * SpikeTravelSpeed, ForceMode2D.Impulse);
			Timer = 0f;
			FiringInterval = Random.value * 10f;
			fired = true;
		}
		if (fired == true&&Timer>=TravelTime) {
			MyRigid.velocity = Vector2.zero;
			transform.position = new Vector3 (OriginalPosX,OriginalPosY,OriginaPosZ);
			transform.Rotate (Rotation);
			fired = false;
			Timer = 0f;
		}
	}

