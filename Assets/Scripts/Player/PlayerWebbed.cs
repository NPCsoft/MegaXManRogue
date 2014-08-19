using UnityEngine;
using System.Collections;

public class PlayerWebbed : MonoBehaviour {

	public static Animator anim;
	public static bool didHit = false;
	
	// Use this for initialization
	void Start () {
		didHit = false;
		anim = gameObject.GetComponent<Animator>();
		Destroy (gameObject, 1f);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!didHit){
			if (gameObject.transform.localScale.x == -1)
				transform.Translate (Vector3.right * -15f * Time.deltaTime);
			else
				transform.Translate (Vector3.right * 15f * Time.deltaTime);	
			
		}
	}

	void OnTriggerEnter2D (Collider2D enemy)
	{
		if (enemy.tag == "Enemy")
		{
			anim.SetTrigger ("webhit");
			didHit = true;
			Destroy (gameObject, 0.4f);
		}
	}
}
