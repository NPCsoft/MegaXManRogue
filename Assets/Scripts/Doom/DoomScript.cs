using UnityEngine;
using System.Collections;

public class DoomScript : MonoBehaviour {

	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;

	public float refiretimer = 2f;
	public float refiretimermax = 2f;

	public Transform playerLocation;
	public Transform doomSprite;	
	public Transform doomPosition;

	public float vertSpeed = 5f;
	public float moveSpeed = 5f;
	public bool jumping = false;
	public bool falling = false;
	public bool moveLeft = false;
	public bool moveRight = false;
	public bool lastDirectionLeft = false;


	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		anim = doomSprite.GetComponent<Animator>();
		Invoke ("PinkGround",3f);
	
	}
	
	// Update is called once per frame
	void Update () {
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);

		if (jumping)
		{
			transform.Translate (Vector3.up * vertSpeed * Time.deltaTime);
		}	

		if (falling)
		{
			transform.Translate (Vector3.up * -vertSpeed * Time.deltaTime);
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

	void PinkGround() 
	{
		anim.Play ("PinkGround");
		Invoke ("JumpToMid",1f);
	}

	void JumpToMid()
	{
		jumping = true;
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
		Invoke ("AirPink",1f);
	}

	void AirPink()
	{
		jumping = false;
		moveLeft = false;
		moveRight = false;
		anim.Play ("AirPink");
		Invoke ("ContinueFall",1f);
	}

	void ContinueFall()
	{
		falling = true;
		if (lastDirectionLeft)
			moveLeft = true;
		else
			moveRight = true;

		Invoke ("GroundBeam",1f);
	}

	void GroundBeam()
	{
		if (doomPosition.localPosition.x > playerLocation.localPosition.x)
		{
			doomSprite.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			doomSprite.localScale = new Vector3 (1,1,1);
		}
	}
}
