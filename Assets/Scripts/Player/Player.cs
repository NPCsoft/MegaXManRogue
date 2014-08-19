using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	public Transform playerSprite;
	public Animator currentboss;
	public GameObject cyclops;

	public float speed = 4f;
	public float walkSpeed = 4f;
	public float dashSpeed = 15f;
	public float fallSpeed = 10f;
	public float JumpForce = 800f;
	public float WallJumpForce = 900f;
	public float WallJumpXForce = 250f;
	public float slidespeed = 3f;
	public float dashModifier = 3f;
	public float wallslideDelay = 0.1f;
	public float timer = 0.2f;
	public static float hitstuntimer = 1f;
	public float endhitstuntimer = 1f;
	public static float iframetimer = 3f;
	public float endiframetimer = 3f;
	public float flashtimer = 3f;
	public GameObject DamageDetector;
	public static float attacktimer = 1f;
	public float endattacktimer = 1f;
	public static float dashTimer = 1.5f;
	public static bool lastDirectionRight = true;
	public static bool Grounded = false;
	public static bool WallLeft = false;
	public static bool WallRight = false;
	public static bool isDashing = false;
	public bool wallSlide = true;
	public static Animator anim;
	public SpriteRenderer mysprite;

	//Weapons stuff
	public static float Laserrefiretimer = 0.5f;
	//Juggernaut invulnerability uses iframetimer and/or GameObject DamageDetector listed above ^^^


	void Start () {
		anim = playerSprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//timer limits control after walljumping
		timer += Time.deltaTime;
		//dashTimer limits the time a single ground dash lasts
		dashTimer += Time.deltaTime;
		//attacktimer prevents movement during attack animations
		//******ATTACK TIMER SHOULD BE SET TO ZERO IN ANIMATION VIA SPRITE SCRIPT*****
		attacktimer += Time.deltaTime;
		//hitstun timer prevents movement when you get hit (should prevent all input)
		hitstuntimer += Time.deltaTime;
		//iframetimer prevents being hit
		iframetimer += Time.deltaTime;
		//flashtimer flashes during iframes
		flashtimer += Time.deltaTime;
		//laserrefiretime for magneto weapon
		Laserrefiretimer += Time.deltaTime;

		mysprite = GetComponentInChildren<SpriteRenderer>();

		//iframe flashing

		if (iframetimer < endiframetimer && flashtimer > 0.05f)
		{
			if (mysprite.color.a > 0.5f)
				mysprite.color = new Vector4 (mysprite.color.r,mysprite.color.g,mysprite.color.b,0.4f);
			else
				mysprite.color = new Vector4 (mysprite.color.r,mysprite.color.g,mysprite.color.b,1f);
			flashtimer = 0f;
		}

		if (iframetimer > endiframetimer && mysprite.color.a < 1f)
			mysprite.color = new Vector4 (mysprite.color.r,mysprite.color.g,mysprite.color.b,1f);

		//actual invincibility
		if (iframetimer < endiframetimer && DamageDetector.activeSelf == true)
			DamageDetector.SetActive (false);

		if (iframetimer > endiframetimer && DamageDetector.activeSelf == false)
			DamageDetector.SetActive (true);

//		if (Input.GetButtonDown ("debugtest"))
//		{
//			anim.SetTrigger("Hurt");
//			hitstuntimer = 0f;
//		}

		if (isDashing && Grounded && PlayerPrefs.GetInt ("JuggernautLevel") == 1)
			iframetimer = 1.4f;



		float move = Input.GetAxis ("Horizontal");
		
			//animation stuff
		if (currentboss != null || cyclops != null){
		if (!currentboss.GetCurrentAnimatorStateInfo(0).IsName ("Intro")){

		anim.SetFloat("Speed",Mathf.Abs (move));
			}}

		if (Grounded)
			anim.SetBool("Grounded",true);
		else
			anim.SetBool("Grounded",false);

		if (isDashing)
			anim.SetBool("Dashing",true);
		else
			anim.SetBool("Dashing",false);

		//0.5f is max time for dash on ground
		if (dashTimer < 0.7f)
			isDashing = true;
		else
			isDashing = false;

		//dash stops & knockback & iframetimer reset
		if (hitstuntimer < endhitstuntimer)
		{
			dashTimer = 1f;
			iframetimer = 0f;

			/// if !WallLeft is needed to prevent wall walking bug
			if (!WallLeft)
			{
				if (lastDirectionRight)
					transform.Translate(Vector2.right * -3 * Time.deltaTime);
				else
					transform.Translate(Vector2.right * 3 * Time.deltaTime);
			}
		}

		if (wallslideDelay > 0.1f)
			wallSlide = true;
		else
			wallSlide = false;
		if (currentboss != null ||  cyclops != null){
		if (!currentboss.GetCurrentAnimatorStateInfo(0).IsName ("Intro")){

		if (!anim.GetCurrentAnimatorStateInfo(0).IsName( "Webbed")){
		//standard horizontal movement

		if (move > 0.1 && WallRight != true && rigidbody2D.velocity.x == 0 || 
		    move < -0.1 && WallLeft != true && rigidbody2D.velocity.x == 0)
		{
			if (!Grounded && hitstuntimer > endhitstuntimer || Grounded && !isDashing 
			    && attacktimer > endattacktimer && hitstuntimer > endhitstuntimer)
				transform.Translate(Vector2.right * move * speed * Time.deltaTime);
			//If you change direction mid-dash, dash ends immediately
			if (Grounded && isDashing && lastDirectionRight == true && move <= -0.1f ||
			    Grounded && isDashing && lastDirectionRight == false && move >= 0.1f)
				dashTimer = 1f;
		}
		//lastDirection needs to be tracked for dashing, and sprite flipping
		if (move > 0.1 && !lastDirectionRight && hitstuntimer > endhitstuntimer)
		{
			anim.SetTrigger("DirectionChange");
			lastDirectionRight = true;
			playerSprite.localScale = new Vector3 (1,1,1);
		}
		if (move < -0.1 && lastDirectionRight && hitstuntimer > endhitstuntimer)
		{
			anim.SetTrigger("DirectionChange");
			lastDirectionRight = false;
			playerSprite.localScale = new Vector3 (-1,1,1);

		}
		
		//dashTimer toggles isDashing until 0.5f
		if (Input.GetButtonDown ("Dash") && Grounded && attacktimer > endattacktimer
		    && hitstuntimer > endhitstuntimer)
		{
			dashTimer = 0f;
		}
		
		//standard dashing
		if (Input.GetButton ("Dash") && isDashing)
		{
			if (Grounded)
			{
				if (lastDirectionRight == true && !WallRight)
				{
					transform.Translate(Vector2.right * speed * Time.deltaTime);
				}
				if (lastDirectionRight == false && !WallLeft)
				{
					transform.Translate(Vector2.right * -speed * Time.deltaTime);
				}
			}
		}
		//Dash ends when you let go of button
		//Will not slow down until grounded
		if (Input.GetButtonUp ("Dash"))
			dashTimer = 1f;
		
		//Set movespeed for whether you're dashing or not, affects horizontal jump movement
		//Will not change midair, so dash jumps can continue after dash is let go
		if (Grounded && isDashing)
		{
			speed = dashSpeed;
		}
		if (Grounded && !isDashing)
		{
			speed = walkSpeed;
		}
		
		// timer = time before regaining control after wall jump
		if (timer > 0.1f)
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		
		//standard jump
		if (Input.GetButtonDown ("Jump"))
		{
			if (Grounded && hitstuntimer > endhitstuntimer)
			{
				Jump();
			}
		}
		
		//tapping jumps lower than holding
		if (Input.GetButtonUp ("Jump") && rigidbody2D.velocity.y >= 0)
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
		
		//falling uniformly, gravity should be on
		//fallspeed = terminal velocity
		if (!Grounded && !WallLeft || !Grounded && !WallRight ||
		    !Grounded && WallLeft && move > -0.1f || !Grounded && WallRight && move < 0.1f)
		{
			if (rigidbody2D.velocity.y <= -fallSpeed)
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -fallSpeed);
		}
		
		//wall sliding!
		//slidedelay is used to cling momentarily
		if (WallLeft && rigidbody2D.velocity.y < 0.1f && Grounded == false && move < -0.1f|| 
		    WallRight && rigidbody2D.velocity.y < 0.1f && Grounded == false && move > 0.1f)
		{			
			anim.SetBool("WallSliding",true);

			wallslideDelay += Time.deltaTime;
			rigidbody2D.velocity = Vector2.zero;
			if (wallSlide == true)
			{
				rigidbody2D.velocity = Vector2.zero;
				transform.Translate (Vector2.up * -slidespeed * Time.deltaTime);
			}
		}
		else
		{
			wallslideDelay = 0f;
			anim.SetBool("WallSliding",false);
	}
		
		//wall jumping! number indicates direction
		if (WallLeft)
		{
			if (!Grounded && Input.GetButtonDown ("Jump"))
			{
				if (Input.GetButton ("Dash"))
				{
					rigidbody2D.velocity = Vector2.up * slidespeed;
					DashWallJump(1);
				}
				else
				{
					rigidbody2D.velocity = Vector2.up * slidespeed;
					WallJump (1);
				}
			}
		}
		if (WallRight)
		{
			if (!Grounded && Input.GetButtonDown ("Jump"))
			{
				if (Input.GetButton ("Dash"))
				{
					rigidbody2D.velocity = Vector2.up * slidespeed;
					DashWallJump(-1);
				}
				else
				{
					rigidbody2D.velocity = Vector2.up * slidespeed;
					WallJump (-1);
				}
			}
		}

		//Attack stuff anim.getcurrentblahblah makes it so GroundAttack can't queue up while ComboP3 plays
		if (Input.GetButtonDown("Attack"))
		{
			if (Grounded && !isDashing && hitstuntimer > endhitstuntimer && !anim.GetCurrentAnimatorStateInfo(0).IsName("ComboP3"))
			{
				attacktimer = 0f;
				anim.SetTrigger("GroundAttack");
			}
			if (!Grounded && !wallSlide && hitstuntimer > endhitstuntimer && !anim.GetCurrentAnimatorStateInfo (0).IsName("AirAttack"))
				anim.SetTrigger ("AirAttack");
		}
	}
		}
		}
	}
	
	void Jump()
	{
		anim.SetTrigger("Jump");
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (Vector2.up * JumpForce);
	}
	
	void WallJump(int direction)
	{
		anim.SetTrigger("Jump");
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (Vector2.up * WallJumpForce);
		rigidbody2D.AddForce (Vector2.right * direction * WallJumpXForce);
		timer = 0f;
		speed = walkSpeed;
	}
	
	void DashWallJump(int direction)
	{
		anim.SetTrigger("Jump");
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (Vector2.up * WallJumpForce);
		rigidbody2D.AddForce (Vector2.right * direction * WallJumpXForce * dashModifier);
		timer = 0f;
		speed = dashSpeed;
	}
	
}


