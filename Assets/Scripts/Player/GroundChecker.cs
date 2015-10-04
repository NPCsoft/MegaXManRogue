using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
	public AudioClip landing;
	public int _count;

	// Use this for initialization
	void Start () {
		_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{	
			GetComponent<AudioSource>().PlayOneShot (landing);
			++_count;
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Player.Grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			--_count;
			if (_count == 0)
			{
				Player.Grounded = false;
				Player.dashTimer = 1f;
				GetComponent<AudioSource>().volume = 0.05f;
			}
		}
	}
}
