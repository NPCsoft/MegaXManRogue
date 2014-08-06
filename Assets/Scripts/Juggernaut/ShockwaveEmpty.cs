using UnityEngine;
using System.Collections;

public class ShockwaveEmpty: MonoBehaviour {


	// Use this for initialization
	void Start () {
		GameObject originalscale = GameObject.Find("SmashParticles(Clone)");
		transform.localScale = originalscale.transform.localScale;
		Destroy (gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {


	}
}
