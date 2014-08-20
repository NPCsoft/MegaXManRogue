using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public int damage = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Used to detect whether you hit an enemy
	void OnTriggerEnter2D (Collider2D enemy)
	{
		if (enemy.tag == "Enemy"){
			if (gameObject.name == "PlayerAngleLaser(Clone)" && enemy.gameObject.name == "Juggernaut"
			    || gameObject.name == "PlayerAngleLaser(Clone)" && enemy.gameObject.name == "Wolverine")
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 3);
			else if (gameObject.name == "PlayerWebProjectile(Clone)" && enemy.gameObject.name == "Magneto")
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 3);
			else if (gameObject.name == "PlayerAngleLaser(Clone)" && enemy.gameObject.name == "Doom")
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 2);
			else if (gameObject.name == "PlayerWebProjectile(Clone)" && enemy.gameObject.name == "Doom")
				return;
			else
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
		if (enemy.tag == "Cyclops"){
			if (gameObject.name == "PlayerWebProjectile(Clone)")
				enemy.gameObject.GetComponent<EnemyHealth2>().TakeDamage(damage * 4);
			else
				enemy.gameObject.GetComponent<EnemyHealth2>().TakeDamage(damage);
		}
	}
}
