using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

	public int damage = 2;
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
			if (gameObject.name == "PlayerAngleLaser(Clone)" && enemy.gameObject.name == "Juggernaut")
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage * 2);
			else
				enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
		if (enemy.tag == "Cyclops"){
			enemy.gameObject.GetComponent<EnemyHealth2>().TakeDamage(damage);
		}
	}
}
