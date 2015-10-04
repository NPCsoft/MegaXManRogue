using UnityEngine;
using System.Collections;

public class PlayMusicAfterDelay : MonoBehaviour {
	public float delay = 5f;
	public AudioClip music;
	// Use this for initialization
	void Start () {
		Invoke ("PlayMusic", delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayMusic()
	{
		GetComponent<AudioSource>().clip = music;
		GetComponent<AudioSource>().Play();
	}
}
