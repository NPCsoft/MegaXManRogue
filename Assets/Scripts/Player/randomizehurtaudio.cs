using UnityEngine;
using System.Collections;

public class randomizehurtaudio : MonoBehaviour {

	public AudioClip hurt1;
	public AudioClip hurt2;
	public int hurtnum;

	// Use this for initialization
	void OnEnable () 
	{
		hurtnum = Random.Range (0,2);
		if (hurtnum == 0)
			GetComponent<AudioSource>().PlayOneShot (hurt1);
		else
			GetComponent<AudioSource>().PlayOneShot (hurt2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
