using UnityEngine;
using System.Collections;

public class LoadContinueOnClickNGP : MonoBehaviour {
	public string levelName;
	public string levelName2;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
		{
			if (PlayerPrefs.GetInt("NGP") == 1)
				Application.LoadLevel(levelName2);
			else
				Application.LoadLevel(levelName);
		}
	}
}
