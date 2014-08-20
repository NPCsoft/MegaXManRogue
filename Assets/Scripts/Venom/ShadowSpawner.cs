using UnityEngine;
using System.Collections;

public class ShadowSpawner : MonoBehaviour {

	public float refiretimer = 0f;

	public GameObject ShadowWoosh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnEnable () {
		refiretimer = 5f;
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player" && refiretimer > 2f)
		{
			Instantiate (ShadowWoosh, transform.position, Quaternion.identity);
			refiretimer = 0f;
		}
	}
}
