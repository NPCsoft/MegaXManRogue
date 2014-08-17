using UnityEngine;
using System.Collections;

public class LoadLevelOnClick : MonoBehaviour {

	public string levelName;
	public Material myMaterial;

	void Start()
	{
		if (PlayerPrefs.GetInt(levelName) == 1)
			myMaterial.shader = Shader.Find ("Diffuse");
		else
			myMaterial.shader = Shader.Find ("Unlit/Texture");
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			Application.LoadLevel(levelName);
	}
}
