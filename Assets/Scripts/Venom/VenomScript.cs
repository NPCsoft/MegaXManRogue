using UnityEngine;
using System.Collections;

public class VenomScript : MonoBehaviour {

	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;
	public Transform playerLocation;
	public static float refiretimer = 2f;
	public Transform venomSprite;	

	public AudioClip web;
	public AudioClip bite;
	public AudioClip shadow;

	public static bool crawling = false;
	public static bool whaling = false;
	public static bool canturn = true;
	public float crawlspeed = 4f;
	public float whalespeed = 15f;

	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		anim = venomSprite.GetComponent<Animator>();
		Invoke ("Taunt",3f);
	
	}
	
	// Update is called once per frame
	void Update () {
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);
		refiretimer += Time.deltaTime;

		if (crawling && venomSprite.localScale.x == -1)
			transform.Translate (Vector3.right * -crawlspeed * Time.deltaTime);
		if (crawling && venomSprite.localScale.x == 1)
			transform.Translate (Vector3.right * crawlspeed * Time.deltaTime);

		if (whaling && venomSprite.localScale.x == -1)
			transform.Translate (Vector3.right * -whalespeed * Time.deltaTime);
		if (whaling && venomSprite.localScale.x == 1)
			transform.Translate (Vector3.right * whalespeed * Time.deltaTime);

//		if (!crawling && !whaling && canturn){
//		if (transform.localPosition.x > playerLocation.localPosition.x &&
//		    venomSprite.localScale.x == 1f)
//			venomSprite.localScale = new Vector3 (-1,1,1);
//		if (transform.localPosition.x < playerLocation.localPosition.x &&
//		    venomSprite.localScale.x == -1f)
//			venomSprite.localScale = new Vector3 (1,1,1);
//		}
	}

	void Taunt (){
		canturn = true;
		anim.Play ("TauntBody");
		Invoke ("WebAttack", 2.5f);
	}

	void WebAttack (){
		audio.PlayOneShot (web);
		anim.Play ("Webshot");
		Invoke ("Crawl", 2f);
	}

	void Crawl (){
		crawling = true;
		anim.Play ("Crawl");
		if (Webbing.didHit)
			Invoke ("Licking",Webbing.distancetraveled * 2);
		else
			Invoke ("BigBite", 1f);
	}

	void Licking(){
		audio.PlayOneShot (bite);
		crawling = false;
		anim.Play ("Lick");
		Invoke ("Whale",2f);
	}

	void BigBite(){
		audio.PlayOneShot (bite);

		crawling = false;
		anim.Play ("BigBite");
		Invoke ("Whale",2f);
	}

	void Whale(){
		anim.Play ("Crawl");
		whaling = true;
		Invoke ("WhaleBreak",1f);
	}

	void WhaleBreak(){
		anim.Play ("Idle");
		canturn = false;
		whaling = false;
		
		if (transform.position.x > 4f)
			venomSprite.localScale = new Vector3 (-1,1,1);
		else
			venomSprite.localScale = new Vector3 (1,1,1);

		Invoke ("ShadowStrike",1f);

	}
	

	void ShadowStrike(){

		audio.PlayOneShot (shadow);

		anim.Play ("ShadowStrike");
		Invoke ("Taunt",4f);
	}
}
