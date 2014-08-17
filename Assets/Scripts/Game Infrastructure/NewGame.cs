using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			PlayerPrefs.DeleteAll();
	}

}
