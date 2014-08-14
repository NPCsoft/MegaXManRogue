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

	public float JumpForce = 10f;
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

//		if (jumping)
//		{
//			transform.Translate (Vector3.up * vertSpeed * Time.deltaTime);
//		}	
//
		if (falling)
		{
//			transform.Translate (Vector3.up * -vertSpeed * Time.deltaTime);
			rigidbody2D.gravityScale = 1f;
		}
		else
		{
			rigidbody2D.gravityScale = 0f;
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
		anim.Play ("PinkGround");
		Invoke ("JumpToMid",1f);
	}

	void JumpToMid()
	{
//		jumping = true;
		rigidbody2D.AddForce (Vector2.up * JumpForce);
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
		rigidbody2D.velocity = Vector2.zero;

		moveLeft = false;
		moveRight = false;
		anim.Play ("AirPink");
		Invoke ("ContinueFallMid",1f);
	}

	void ContinueFallMid()
	{
		falling = true;
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
			rigidbody2D.AddForce (Vector2.up * JumpForce);
		}
		else
		{
			moveRight = true;
//			jumping = true;
			rigidbody2D.AddForce (Vector2.up * JumpForce);
		}

		Invoke ("AirBeam",0.5f);
	}

	void AirBeam()
	{
//		jumping = false;
		rigidbody2D.velocity = Vector2.zero;

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
		anim.Play ("AirBeam");
		Invoke ("ContinueFallEdge",1f);
	}

	void ContinueFallEdge()
	{
		falling = true;
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
