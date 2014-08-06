using UnityEngine;
using System.Collections;

public class ShadowSpawner : MonoBehaviour {


	public GameObject ShadowWoosh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player")
			Instantiate (ShadowWoosh, transform.position, Quaternion.identity);
	}
}
