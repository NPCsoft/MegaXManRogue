using UnityEngine;
using System.Collections;

public class randomizewinaudio : MonoBehaviour {

	public AudioClip win1;
	public AudioClip win2;
	public AudioClip win3;
	public int winnum;
	
	// Use this for initialization
	void OnEnable () 
	{
		winnum = Random.Range (0,3);
		if (winnum == 0)
			audio.PlayOneShot (win1);
		else if (winnum == 1)
			audio.PlayOneShot (win2);
		else
			audio.PlayOneShot (win3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
