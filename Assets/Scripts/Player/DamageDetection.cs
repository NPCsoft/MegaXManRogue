using UnityEngine;
using System.Collections;

public class DamageDetection : MonoBehaviour {
	public Transform playerHealthBar;
	public static Animator anim;
	public static float currentHealth = 28;
	public GameObject playerPlayer;

	// Use this for initialization
	void Start () {
		anim = playerHealthBar.GetComponent<Animator>();
		anim.SetFloat ("playerHealth",currentHealth);
	}
	
	// Update is called once per frame
	void Update () {

		if (playerPlayer.transform.position.y < -5f)
		{
			anim.SetFloat ("playerHealth",0);
			currentHealth = 0f;
		}

		if (currentHealth > 28f)
			currentHealth = 28f;
		if (currentHealth <= 0f)
		{
			if (Player.lastDirectionRight == true)
			{
				Player.anim.Play("Death");
				playerPlayer.GetComponent<Player>().enabled = false;
				Invoke ("ReloadLevel", 5f);
			}
			else
			{
				Player.anim.Play ("DeathRight");
				playerPlayer.GetComponent<Player>().enabled = false;
				Invoke ("ReloadLevel", 5f);

			}
		}
	}

	void ReloadLevel()
	{
		currentHealth = 28f;

		if (Application.loadedLevelName != "IntroLevel")
		{ 
			if(PlayerPrefs.GetInt("NGP") == 1)
				Application.LoadLevel ("StageSelectNGP");
			else
				Application.LoadLevel("StageSelect");
		}
		else
			Application.LoadLevel("MainMenu");
	}

	//used to detect when you take damage
	void OnTriggerEnter2D(Collider2D enemy)
	{
		if (enemy.gameObject.tag == "Enemy" || enemy.gameObject.tag == "EnemyAttack")
		{
			if (enemy.gameObject.name == "LASERDAMAGE")
			{
				if (currentHealth <= 10f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
				Player.anim.SetTrigger("Hurt");
				currentHealth -= 10f;
				Player.hitstuntimer = 0f;
				Player.iframetimer = 0f;
				anim.SetFloat("playerHealth" , currentHealth);
				}
			}
				else if (enemy.gameObject.name == "AngleLaser(Clone)")
			{
				if (currentHealth <= 6f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 6f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}
			else if (enemy.gameObject.name == "GroundShock1" 
			         || enemy.gameObject.name == "GroundShock21" 
			         || enemy.gameObject.name == "GroundShock31"
			         || enemy.gameObject.name == "GroundShock41")
			{
				if (currentHealth <= 8f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 8f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}
			else if (enemy.gameObject.name == "SmashParticles(Clone)" || enemy.gameObject.name == "SmashParticlesEmpty(Clone)")
			{
				if (currentHealth <= 8f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 8f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}
			else if (enemy.gameObject.name == "ChargeParticles")
			{
				if (currentHealth <= 8f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 8f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "WebProjectile(Clone)")
			{
				if (currentHealth <= 1f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Webbed");
					currentHealth -= 1f;
					//no knockback cause webbed
//					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
					Webbing.anim.SetTrigger ("webhit");
					Webbing.didHit = true;
					Destroy (enemy.gameObject,0.3f);
				}
			}

			else if (enemy.gameObject.name == "LickAttack")
			{
				if (currentHealth <= 8f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 8f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "WhaleAttack")
			{
				if (currentHealth <= 5f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 5f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "ShadowStrikeAttack(Clone)")
			{
				if (currentHealth <= 4f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 4f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "DrillClaw")
			{
				if (currentHealth <= 6f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 6f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "OpticBlast(Clone)")
			{
				if (currentHealth <= 4f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 4f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "GroundBeam")
			{
				if (currentHealth <= 6f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 6f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

			else if (enemy.gameObject.name == "Pink1(Clone)")
			{
				if (currentHealth <= 5f)
				{
					currentHealth = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
				else
				{
					Player.anim.SetTrigger("Hurt");
					currentHealth -= 5f;
					Player.hitstuntimer = 0f;
					Player.iframetimer = 0f;
					anim.SetFloat("playerHealth" , currentHealth);
				}
			}

				else
				{			
				if (currentHealth <= 3f)
					{
						currentHealth = 0f;
						anim.SetFloat("playerHealth" , currentHealth);
					}
					else
					{
						Player.anim.SetTrigger("Hurt");
						currentHealth -= 3f;
						Player.hitstuntimer = 0f;
						Player.iframetimer = 0f;
						anim.SetFloat("playerHealth" , currentHealth);
					}
				}

		}
	}
}
