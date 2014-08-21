using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	// Use this for initialization

	void Update()
	{
		if (Input.GetButtonDown ("Dash") || Input.GetButtonDown ("Jump") || Input.GetButtonDown("Attack"))
			PlayerPrefs.DeleteAll();
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			PlayerPrefs.DeleteAll();
	}

}
