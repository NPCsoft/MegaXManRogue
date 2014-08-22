using UnityEngine;
using System.Collections;

public class NewGamePlus : MonoBehaviour {

	// Use this for initialization
	void Update()
	{
		if (PlayerPrefs.GetInt ("DoomLevel") == 1) 
		{
		if (Input.GetButtonDown ("Dash") || Input.GetButtonDown ("Jump") || Input.GetButtonDown("Attack"))
			PlayerPrefs.SetInt("NGP",1);
		
		if (Input.GetMouseButtonDown (0))
			PlayerPrefs.SetInt("NGP",1);
		}
	}
}
