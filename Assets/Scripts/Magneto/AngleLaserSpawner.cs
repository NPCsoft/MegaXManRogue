using UnityEngine;
using System.Collections;

public class AngleLaserSpawner : MonoBehaviour {

	public Transform here;
	public Transform spriteScale;
	public GameObject AngleLaser;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Magneto.refiretimer > 0.5f)
			AngleLaserSpawn();

	}
	void AngleLaserSpawn(){
		Magneto.refiretimer = 0f;
		GameObject Projectile = Instantiate (AngleLaser, new Vector3 (here.position.x,here.position.y), Quaternion.identity) as GameObject;
		Projectile.transform.localScale = spriteScale.localScale;
	}
}
