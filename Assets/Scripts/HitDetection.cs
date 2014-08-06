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
			enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
	}
}
