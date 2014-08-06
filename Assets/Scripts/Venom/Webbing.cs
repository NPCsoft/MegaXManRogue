using UnityEngine;
using System.Collections;

public class Webbing : MonoBehaviour {

	public static Animator anim;
	public static float distancetraveled;
	public static bool didHit = false;

	// Use this for initialization
	void Start () {
		didHit = false;
		distancetraveled = 0f;
		anim = gameObject.GetComponent<Animator>();
		Destroy (gameObject, 1f);

	}
	
	// Update is called once per frame
	void Update () 
	{
		distancetraveled += Time.deltaTime;

		if (!didHit){
			if (gameObject.transform.localScale.x == -1)
				transform.Translate (Vector3.right * -15f * Time.deltaTime);
			else
				transform.Translate (Vector3.right * 15f * Time.deltaTime);	

			transform.Translate (Vector3.up * -1f * Time.deltaTime);
		}
	}

}
