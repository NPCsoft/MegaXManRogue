using UnityEngine;
using System.Collections;

public class PlayerAngleLaserSpawner : MonoBehaviour {

	public Transform here;
	public Transform spriteScale;
	public GameObject PlayerAngleLaser;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.Laserrefiretimer > 0.5f && PlayerPrefs.GetInt ("MagnetoLevel") == 1)
			AngleLaserSpawn();
		
	}
	void AngleLaserSpawn(){
		Player.Laserrefiretimer = 0f;
		GameObject Projectile = Instantiate (PlayerAngleLaser, new Vector3 (here.position.x,here.position.y), Quaternion.identity) as GameObject;
		Projectile.transform.localScale = spriteScale.localScale / 2;
	}
}