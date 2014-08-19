using UnityEngine;
using System.Collections;

public class PlayerWebShooter : MonoBehaviour {

	// Use this for initialization
	public Transform here;
	public Transform spriteScale;
	public GameObject PlayerWebShot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.Laserrefiretimer > 0.5f && PlayerPrefs.GetInt ("VenomLevel") == 1)
			WebSpawn();
		
	}
	void WebSpawn(){
		Player.Laserrefiretimer = 0f;
		GameObject Projectile = Instantiate (PlayerWebShot, new Vector3 (here.position.x,here.position.y), Quaternion.identity) as GameObject;
		Projectile.transform.localScale = spriteScale.localScale;
	}
}