﻿using UnityEngine;
using System.Collections;

public class Sentinel : MonoBehaviour {
	public Transform playerTransform;
	public Transform sentinelSprite;
	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;
	public bool playerToTheLeft = true;
	public float dashspeed = 5f;
	public bool dashing = false;
	public bool dashingRight = true;

	// Use this for initialization
	void Start () {
		anim = sentinelSprite.GetComponent<Animator>();
		ShowOff();
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
	}
	void Update (){
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);
		if (dashing)
		{
			if (dashingRight)
				transform.Translate (Vector3.right * dashspeed * Time.deltaTime);
			if (!dashingRight)
				transform.Translate (Vector3.right * -dashspeed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void ChangeDirection () {
		if (dashingRight)
			sentinelSprite.localScale = new Vector3 (-1,1,1);
		else
			sentinelSprite.localScale = new Vector3 (1,1,1);

	}

	void ShowOff()
	{
		anim.Play ("Intro");
		Invoke ("LowLaserAttack", 3f);
	}

	void LowLaserAttack()
	{
		dashing = false;
		ChangeDirection();
		anim.Play ("LowLaserAttack");
		Invoke ("LaserAttack",4f);
	}

	void LaserAttack()
	{
		anim.Play("LaserAttack");
		Invoke ("Dash", 3f);
	}

	void Dash()
	{
		if (dashingRight)
			dashingRight = false;
		else
			dashingRight = true;
		dashing = true;
		anim.Play("ForwardDash");
		Invoke ("LowLaserAttack", 2f);
	}
}