using UnityEngine;
using System.Collections;

public class LoadLevelOnClickNGP : MonoBehaviour {

	public string levelName;

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			Application.LoadLevel(levelName);
	}
}
