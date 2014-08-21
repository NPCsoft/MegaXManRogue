using UnityEngine;
using System.Collections;

public class Magneto : MonoBehaviour {
	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;
	public Transform playerLocation;
	public static float refiretimer = 2f;
	public Transform magnetoSprite;	
	public bool goUp = false;
	public bool goDown = false;
	public bool goLeft = false;
	public bool goRight = false;
	public float vertSpeed = 3f;
	public float horzSpeed = 3f;
	public bool whichWay = true;

	public AudioClip supreme;
	public AudioClip chuckle;
	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		Invoke ("GetAirborn",3f);
		anim = magnetoSprite.GetComponent<Animator>();
		audio.PlayOneShot (supreme);

	}
	
	// Update is called once per frame
	void Update () {
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);
		anim.SetFloat("xScale", magnetoSprite.localScale.x);

		if (EnemyHealth.dead)
		{
			CancelInvoke();
			goUp = false;
			goDown = false;
			goLeft = false;
			goRight = false;
			anim.SetTrigger ("Dead");
			rigidbody2D.gravityScale = 1f;
		}

		if (playerLocation.position.x > transform.position.x){
			magnetoSprite.transform.localScale = new Vector3 (1,1,1);
			magnetoSprite.transform.localPosition = new Vector3 (0.5f,0f,0f);
		}
		else{
			magnetoSprite.transform.localScale = new Vector3 (-1,1,1);
			magnetoSprite.transform.localPosition = new Vector3 (0,0,0);
		}
		refiretimer += Time.deltaTime;

		if (goUp)
			transform.Translate (Vector3.up * vertSpeed * Time.deltaTime);
		if (goDown)
			transform.Translate (-Vector3.up * vertSpeed * Time.deltaTime);
		if (goRight)
			transform.Translate (Vector3.right * horzSpeed * Time.deltaTime);
		if (goLeft)
			transform.Translate (-Vector3.right * horzSpeed * Time.deltaTime);
	
	}

	void GetAirborn(){
		goUp = true;
		InvokeRepeating ("Oscilate",1.75f,1f);
		Invoke ("StrafingRunLeft",1.75f);
	}

	void StrafingRunLeft(){
		horzSpeed = Random.Range (2f,6f);
		goUp = false;
		goLeft = true;
		anim.Play ("DownwardLaser");
		Invoke ("MiddleMan",4f);
	}
	void StrafingRunRight(){
		goUp = false;
		goRight = true;
		anim.Play ("DownwardLaser");
		Invoke ("MiddleMan",4f);
	}

	void MiddleMan(){
		CancelInvoke("Oscilate");
		goUp = false;
		Invoke ("GetGrounded",0.5f);
	}

	void GetGrounded(){
		goDown = true;
		goLeft = false;
		goRight = false;
		Invoke ("GroundShock",1.75f);
	}

	void GroundShock(){
		audio.PlayOneShot (chuckle);

		anim.Play ("GroundShock");
		Invoke ("GetAirbornToOscilate",3f);
		if (!whichWay){
			Invoke ("StrafingRunLeft",4.75f);
			whichWay = true;
		}
		else{
			Invoke ("StrafingRunRight",4.75f);
			whichWay = false;
		}
	}

	void GetAirbornToOscilate(){
		goUp = true;
		InvokeRepeating ("Oscilate",1.75f,1f);
	}

	void Oscilate(){
		if (goDown)
		{
			goUp = true;
			goDown = false;
			return;
		}
		if (goUp || !goUp && !goDown)
		{
			goDown = true;
			goUp = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Wall"){
			goDown = false;
			CancelInvoke("Oscilate");
		}
		}

}
