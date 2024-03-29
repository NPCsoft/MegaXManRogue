﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform gotolocation;
	public float shakedelay = 3f;
	public float followdelay = 5f;
	public bool follow = false;
	public float followspeed = 5f;
	public float minlimitx = -15f;
	public float maxlimitx = 15f;
	public AudioClip shakesound;
	public float dashfollowspeed = 8f;
	public float walkfollowspeed = 3.5f;
	// Use this for initialization
	void Start () {
		Invoke ("BeginFollow",followdelay);
		BossRoomWalls.camshake = false;
		followspeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.isDashing)
			followspeed = dashfollowspeed;
		if (!Player.isDashing && Player.Grounded)
			followspeed = walkfollowspeed;
		shakedelay += Time.deltaTime;

		if (follow)
		{
			if (gotolocation.position.x > transform.position.x + 0.5f)
			{
				if (transform.position.x < maxlimitx)
				{
					transform.Translate (Vector2.right * followspeed * Time.deltaTime);
				}
			
			}

			if (gotolocation.position.x < transform.position.x - 0.5f)
			{
			    if (transform.position.x > minlimitx)
				{
					transform.Translate (Vector2.right * -followspeed * Time.deltaTime);
				}
			}
		}

		if (BossRoomWalls.camshake == true && shakedelay > 3f)
		{
			transform.Translate (Vector2.up * 0.1f);
			GetComponent<AudioSource>().PlayOneShot (shakesound);
			Invoke ("Deshake", 0.01f);
			shakedelay = 0f;
		}

	
	}

	void BeginFollow()
	{
		follow = true;
	}

	void Deshake()
	{
		transform.Translate (Vector2.up * -0.1f);
		if (BossRoomWalls.camshake == true)
			Invoke ("Reshake",0.05f);
	}

	void Reshake()
	{
		transform.Translate (Vector2.up * 0.1f);
		Invoke ("Deshake", 0.05f);
	}
	
}
