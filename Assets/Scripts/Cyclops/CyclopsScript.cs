using UnityEngine;
using System.Collections;

public class CyclopsScript : MonoBehaviour {
	public Transform bossHealthBar;
	public static Animator healthanim;
	public static Animator anim;
	public Transform cyclopsSprite;
	// Use this for initialization
	void Start () {

		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth2",EnemyHealth2.currentHealth);
		anim = cyclopsSprite.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth2.dead2)
		{
			anim.SetTrigger ("Dead2");
		}
		healthanim.SetFloat("bossHealth2",EnemyHealth2.currentHealth);

	}
}
