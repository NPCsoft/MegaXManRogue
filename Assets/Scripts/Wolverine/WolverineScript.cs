﻿using UnityEngine;
using System.Collections;

public class WolverineScript : MonoBehaviour {

	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;

	public float refiretimer = 2f;
	public float refiretimermax = 2f;
	public float drillspeedx = 8f;
	public float drillspeedy = 2f;
	public Transform playerLocation;
	public Transform wolverineSprite;	
	public static bool wallhit = false; 
	public static bool groundhit = false;
	public bool drillstraight = false;
	public bool drillup = false;
	public bool drilldown = false;
	public bool upordown = false;

	// Use this for initialization
	void Start () 
	{
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		anim = wolverineSprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);
	
		if (wallhit)
		{
			drillstraight = false;
			drillup = false;
			drilldown = false;
			anim.Play ("WallJump");
			if (upordown)
				upordown = false;
			else
				upordown = true;

			if (playerLocation.localPosition.y > transform.localPosition.y)
				Invoke ("DrillUp",0.2f);
			else
				Invoke ("DrillDown",0.2f);
			wallhit = false;
		}

		if (groundhit)
		{
			drilldown = false;
			upordown = false;
			anim.Play ("Idle");
			Invoke ("CrouchtoDrillStraightStarting",2f);
			groundhit = false;
		}

		if (drillstraight){
			if (wolverineSprite.localScale.x > 0f)
				transform.Translate (Vector3.right * drillspeedx * Time.deltaTime);
			else
				transform.Translate (Vector3.right * -drillspeedx * Time.deltaTime);
		}

		if (drillup){
			if (wolverineSprite.localScale.x > 0f)
				transform.Translate (new Vector3 (1 * drillspeedx, 1 * drillspeedy,0) * Time.deltaTime);
			else
				transform.Translate (new Vector3 (1 * -drillspeedx, 1 * drillspeedy,0) * Time.deltaTime);

		}

		if (drilldown)
		{
			if (wolverineSprite.localScale.x > 0f)
			{			
				transform.Translate (new Vector3 (1 * drillspeedx, 1 * -drillspeedy,0) * Time.deltaTime);
			}
			else
				transform.Translate (new Vector3 (1 * -drillspeedx, 1 * -drillspeedy,0) * Time.deltaTime);
			
		}
	}

	void CrouchtoDrillStraightStarting()
	{
		anim.Play ("Crouch");
		Invoke ("DrillStraightStarting",0.2f);
	}

	void Crouch()
	{
		if (wolverineSprite.localScale.x > 0)
		{
			wolverineSprite.localScale = new Vector3 (-1,1,1);
		}
		else
			wolverineSprite.localScale = new Vector3 (1,1,1);
		anim.Play ("Crouch");
	}

	void DrillStraightStarting()
	{
		anim.Play ("DrillClawStraight");
		drillstraight = true;
	}

	void DrillStraight()
	{
		if (wolverineSprite.localScale.x > 0)
			wolverineSprite.localScale = new Vector3 (-1,1,1);
		else
			wolverineSprite.localScale = new Vector3 (1,1,1);
		anim.Play ("DrillClawStraight");
		drillstraight = true;
	}
	

	void DrillUp()
	{
		if (upordown)
			{
			if (wolverineSprite.localScale.x > 0)
			{
				wolverineSprite.localScale = new Vector3 (-1,1,1);
			}
			else
				wolverineSprite.localScale = new Vector3 (1,1,1);
			anim.Play ("DrillClawUp");
			drillup = true;
		}
		else
		{
			Invoke ("DrillStraight",0f);
		}
	}

	void DrillDown()
	{
		if (transform.localPosition.y > -2f){
		if (upordown)
		{
		if (wolverineSprite.localScale.x > 0)
		{
			wolverineSprite.localScale = new Vector3 (-1,1,1);
		}
		else
			wolverineSprite.localScale = new Vector3 (1,1,1);
		anim.Play ("DrillClawDown");
		drilldown = true;
		}
		else
		{
			Invoke ("DrillStraight",0f);
		}
		}
		else
		{
			Invoke ("DrillUp",0f);
		}
	}

}
