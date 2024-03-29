﻿using UnityEngine;
using System.Collections;

public class DoomScript : MonoBehaviour {

	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;

	public static float refiretimer = 2f;
	public static float refiretimermax = 2f;

	public Transform playerLocation;
	public Transform doomSprite;	
	public Transform doomPosition;

	public float JumpForce = 10f;
	public float vertSpeed = 5f;
	public float moveSpeed = 5f;
	public bool jumping = false;
	public bool falling = false;
	public bool moveLeft = false;
	public bool moveRight = false;
	public bool lastDirectionLeft = false;

	public AudioClip pinkbeams;
	public AudioClip yellowbeam;
	public AudioClip laugh;


	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		anim = doomSprite.GetComponent<Animator>();
		Invoke ("PinkGround",3f);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (EnemyHealth.dead)
		{
			CancelInvoke();
			jumping = false;
			falling = true;
			moveLeft = false;
			moveRight = false;

			anim.SetTrigger ("Dead");
		}


		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);
//		if (jumping)
//		{
//			transform.Translate (Vector3.up * vertSpeed * Time.deltaTime);
//		}	
//
		if (falling)
		{
//			transform.Translate (Vector3.up * -vertSpeed * Time.deltaTime);
			GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
		else
		{
			GetComponent<Rigidbody2D>().gravityScale = 0f;
		}

		if (moveLeft)
		{
			transform.Translate (Vector3.right * -moveSpeed * Time.deltaTime);
		}	

		if (moveRight)
		{
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}

	}
	//PINK GROUND REMOVED, JUST TURNS NOW
	void PinkGround() 
	{
		falling = false;
		moveRight = false;
		moveLeft = false;
		if (doomPosition.localPosition.x > playerLocation.localPosition.x)
		{
			doomSprite.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			doomSprite.localScale = new Vector3 (1,1,1);
		}
//		anim.Play ("PinkGround");
		anim.Play ("Idle");
		GetComponent<AudioSource>().PlayOneShot (laugh);
		Invoke ("JumpToMid",1f);
	}

	void JumpToMid()
	{
//		jumping = true;
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * JumpForce);
		anim.Play ("ForwardJump");
		if (doomPosition.localPosition.x > 0f)
		{
			moveLeft = true;
			lastDirectionLeft = true;
		}
		else
		{
			moveRight = true;
			lastDirectionLeft = false;
		}
		Invoke ("AirPink",0.5f);
	}

	void AirPink()
	{
//		jumping = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		if (doomPosition.localPosition.x > playerLocation.localPosition.x)
		{
			doomSprite.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			doomSprite.localScale = new Vector3 (1,1,1);
		}
		moveLeft = false;
		moveRight = false;
		anim.Play ("AirPink");
		GetComponent<AudioSource>().PlayOneShot (pinkbeams);
		Invoke ("ContinueFallMid",1f);
	}

	void ContinueFallMid()
	{
		falling = true;
		anim.Play ("Falling");
		if (lastDirectionLeft)
			moveLeft = true;
		else
			moveRight = true;

		Invoke ("BeamGround",0.5f);
	}

	void BeamGround()
	{
		falling = false;
		moveLeft = false;
		moveRight = false;
		if (doomPosition.localPosition.x > playerLocation.localPosition.x)
		{
			doomSprite.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			doomSprite.localScale = new Vector3 (1,1,1);
		}

		anim.Play ("BeamGround");
		GetComponent<AudioSource>().PlayOneShot (yellowbeam);
		Invoke ("JumpToEdge",1f);
	}

	void JumpToEdge()
	{
		if (lastDirectionLeft && doomSprite.localScale.x == -1)
			anim.Play ("ForwardJump");
		else if (lastDirectionLeft && doomSprite.localScale.x == 1)
			anim.Play ("BackwardJump");
		else if (!lastDirectionLeft && doomSprite.localScale.x == 1)
			anim.Play ("ForwardJump");
		else if (!lastDirectionLeft && doomSprite.localScale.x == -1)
			anim.Play ("BackwardJump");

		if (lastDirectionLeft)
		{
			moveLeft = true;
//			jumping = true;
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * JumpForce);
		}
		else
		{
			moveRight = true;
//			jumping = true;
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * JumpForce);
		}

		Invoke ("AirBeam",0.5f);
	}
	//AIR BEAM REMOVED, DOES AIR PINK INSTEAD
	void AirBeam()
	{
//		jumping = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		if (doomPosition.localPosition.x > playerLocation.localPosition.x)
		{
			doomSprite.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			doomSprite.localScale = new Vector3 (1,1,1);
		}
		moveLeft = false;
		moveRight = false;
		anim.Play ("AirPink");
		GetComponent<AudioSource>().PlayOneShot (pinkbeams);
		Invoke ("ContinueFallEdge",1f);
	}

	void ContinueFallEdge()
	{
		falling = true;
		anim.Play ("Falling");

		if (lastDirectionLeft)
		{
			moveLeft = true;
			lastDirectionLeft = false;

		}
		else
		{
			moveRight = true;
			lastDirectionLeft = true;

		}
		Invoke ("PinkGround",0.5f);
	}

}
