using UnityEngine;
using System.Collections;

public class SlowTextCrawl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 0f)
		{
			transform.Translate (Vector2.up * Time.deltaTime);
		}
		if (gameObject.transform.position.y >= 0f)
		{
			if (Input.anyKeyDown)
				Application.LoadLevel ("MainMenu");
		}
	}
}
