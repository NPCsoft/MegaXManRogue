using UnityEngine;
using System.Collections;

public class AngleProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.localScale.x < 0f)
			transform.Translate (new Vector3 (-5,-5,0) * Time.deltaTime);
		else
			transform.Translate (new Vector3 (5,-5,0) * Time.deltaTime);

		Destroy(gameObject,10f);
	}
}
