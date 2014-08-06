using UnityEngine;
using System.Collections;

public class WebShooter : MonoBehaviour {

	// Use this for initialization
	public Transform here;
	public Transform spriteScale;
	public GameObject WebShot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (VenomScript.refiretimer > 0.5f)
			WebSpawn();
		
	}
	void WebSpawn(){
		VenomScript.refiretimer = 0f;
		GameObject Projectile = Instantiate (WebShot, new Vector3 (here.position.x,here.position.y), Quaternion.identity) as GameObject;
		Projectile.transform.localScale = spriteScale.localScale;
	}
}