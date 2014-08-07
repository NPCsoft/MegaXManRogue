using UnityEngine;
using System.Collections;

public class CyclopsScript : MonoBehaviour {
	public Transform bossHealthBar;
	public static Animator healthanim;
	// Use this for initialization
	void Start () {
		healthanim = bossHealthBar.GetComponent<Animator>();
		healthanim.SetFloat ("bossHealth",EnemyHealth.currentHealth);
	}
	
	// Update is called once per frame
	void Update () {
		healthanim.SetFloat("bossHealth",EnemyHealth.currentHealth);

	}
}
