using UnityEngine;
using System.Collections;

public class OpticBlast : MonoBehaviour {

	public float opticspeed = 10f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.localScale.x == 1)
			transform.Translate (Vector3.right * opticspeed * Time.deltaTime);
		else
			transform.Translate (Vector3.right * -opticspeed * Time.deltaTime);
	}
}
