using UnityEngine;
using System.Collections;

public class Juggernaut : MonoBehaviour {

	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;
	public Transform playerLocation;
	public static float refiretimer = 2f;
	public Transform juggernautSprite;
	public static Transform staticjuggernautSprite;
	public static bool juggerCharge;
	public static bool juggerChargeComplete;
	public Transform shockwaveObj;
	private GameObject instanObj;
	public int randomizer = 1;
	public int lastrandomizer = 2;
	public int lastlastrandomizer = 2;
	public float chargespeed = 5f;
	public float attackpicktimer = 3f;

	// Use this for initialization
	void Start () {
		staticjuggernautSprite = juggernautSprite; 

		healthanim = bossHealthBar.GetComponent<Animator>();
		anim = juggernautSprite.GetComponent<Animator>();
		juggerCharge = false;
		juggerChargeComplete = false;
		Invoke ("AttackPicker", 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth.dead)
		{
			CancelInvoke();
			juggerCharge = false;
			juggerChargeComplete = false;
			anim.SetTrigger ("Dead");
		}

		attackpicktimer += Time.deltaTime;
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);


		if (juggerChargeComplete && attackpicktimer > 3f)
		{
			attackpicktimer = 0f;
			Invoke ("AttackPicker",2f);
		}
		if (juggerCharge){		

			if (juggernautSprite.localScale.x == -1)
				transform.Translate (Vector3.right * -chargespeed * Time.deltaTime);
			else
				transform.Translate (Vector3.right * chargespeed * Time.deltaTime);
		}
	
	}

	void AttackPicker(){
		juggerChargeComplete = false;
		lastlastrandomizer = lastrandomizer;
		lastrandomizer = randomizer;
		randomizer = (int) Random.Range (1f,3f);
		if (randomizer == lastrandomizer && lastrandomizer == lastlastrandomizer)
		{
			if (randomizer == 1)
				randomizer = 2;
			else if (randomizer == 2)
				randomizer = 1;
		}

		if (randomizer == 1)
			Invoke ("Charge",1f);
		else if (randomizer == 2)
			Invoke ("Smash",1f);

		}

	void Smash()
	{
		Invoke("Shockwave",0.3f);
		anim.Play("Smash");
		Invoke ("AttackPicker",2f);
	}

	void Shockwave()
	{
		if (juggernautSprite.localScale.x > 0)
		Instantiate (shockwaveObj,new Vector3(juggernautSprite.position.x + 3f, juggernautSprite.position.y, juggernautSprite.position.z),Quaternion.identity);
		else
			Instantiate (shockwaveObj,new Vector3(juggernautSprite.position.x - 3f, juggernautSprite.position.y, juggernautSprite.position.z),Quaternion.identity);

	
	}

	void Charge()
	{
		anim.Play("Charge");
		juggerCharge = true;
	}

}