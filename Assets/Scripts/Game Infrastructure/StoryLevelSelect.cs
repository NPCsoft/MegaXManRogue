using UnityEngine;
using System.Collections;

public class StoryLevelSelect: MonoBehaviour {
	public Material myMaterial;
	public string levelName;
	public string levelName2;
	public Texture mistertexture;
	public GameObject questionmark;


	void Start()
	{
		if (PlayerPrefs.GetInt ("MagnetoLevel") == 1 && PlayerPrefs.GetInt ("JuggernautLevel") == 1 &&
		    PlayerPrefs.GetInt ("VenomLevel") == 1)
			myMaterial.shader = Shader.Find ("Unlit/Texture");
		else if (PlayerPrefs.GetInt ("MisterSinisterLevel") != 1)
			myMaterial.shader = Shader.Find ("Diffuse");

		if (PlayerPrefs.GetInt ("MagnetoLevel") == 1 && PlayerPrefs.GetInt ("JuggernautLevel") == 1 &&
		    PlayerPrefs.GetInt ("VenomLevel") == 1)
		{
			if (PlayerPrefs.GetInt ("MisterSinisterLevel") != 1)
			{
				questionmark.SetActive (false);
				myMaterial.SetTexture (0, mistertexture);
			}
			else if (PlayerPrefs.GetInt ("MisterSinisterLevel") == 1)
			{
				questionmark.SetActive (true);
				myMaterial.SetTexture (0, null);
				myMaterial.shader = Shader.Find ("Sprites/Default");
				myMaterial.SetColor ("_TintColor", Color.green);
			}
		}
	}

	void OnMouseOver()
	{
		if (PlayerPrefs.GetInt ("MagnetoLevel") == 1 && PlayerPrefs.GetInt ("JuggernautLevel") == 1 &&
		    PlayerPrefs.GetInt ("VenomLevel") == 1)
		{
			if (PlayerPrefs.GetInt ("MisterSinisterLevel") == 1)
			{
				if (Input.GetMouseButtonDown (0))
					Application.LoadLevel(levelName2);
			}
			else
				if (Input.GetMouseButtonDown (0))
					Application.LoadLevel(levelName);
		}
	}
}
