using UnityEngine;
using System.Collections;

public class EnemyHealth2 : MonoBehaviour {
	public int maxHealth = 28;
	public static int currentHealth = 28;
	public int hitstoKill = 28;
	private int damageMultiplier = 1;
	private SpriteRenderer flicker;
	public float rehittimer = 0.3f;
	public Vector4 initialColor = new Vector4(1f,1f,1f,1f);
	public Vector4 flickerColor = new Vector4 (1f,0.4f,0.4f,1f);


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		damageMultiplier = hitstoKill/28;
		flicker = gameObject.GetComponentInChildren<SpriteRenderer>();


	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
			Destroy (gameObject, 0f);
		rehittimer += Time.deltaTime;

	}

	public void TakeDamage(int damage)
	{
		if (rehittimer > 0.5f){
			currentHealth -= damage * damageMultiplier;
			rehittimer = 0f;
		}
		Flicker ();
	}

	public void Flicker()
	{
		flicker.color = flickerColor;
		Invoke ("UnFlicker",0.05f);
	}
	public void UnFlicker()
	{
		flicker.color = initialColor;
	}
}
