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

	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
		anim = doomSprite.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);

	}
}
