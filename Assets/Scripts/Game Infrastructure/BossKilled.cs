using UnityEngine;
using System.Collections;

public class BossKilled : MonoBehaviour {
	// Use this for initialization
	private string stageName;
	private float delay = 0f;
	public GameObject currentBoss;
	public GameObject currentBoss2;
	public GameObject damagedetector;
	void Start () {
		stageName = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;

	if (currentBoss == null && currentBoss2 == null)
		{
			damagedetector.SetActive (false);
			if (delay > 7f)
			{
				delay = 0f;
				if (PlayerPrefs.GetInt(stageName) != 1)
				{
					if (stageName == "MagnetoLevel")
						Invoke ("GetMag",5f);
					else if (stageName == "JuggernautLevel")
						Invoke ("GetJug",5f);
					else if (stageName == "VenomLevel")
						Invoke ("GetVen",5f);
					else if (stageName == "DoomLevel")
						Invoke ("WinScreen",5f);
					else
						Invoke ("BackToStageSelect",5f);
				}
				else
					Invoke ("BackToStageSelect",5f);
			}
		}
	}

	void BackToStageSelect()
	{
		DamageDetection.currentHealth = 28;
		PlayerPrefs.SetInt (stageName, 1);
		Application.LoadLevel ("StageSelect");
	}

	void GetMag()
	{
		DamageDetection.currentHealth = 28;
		PlayerPrefs.SetInt (stageName, 1);
		Application.LoadLevel ("MagnetoGet");
	}

	void GetJug()
	{
		DamageDetection.currentHealth = 28;
		PlayerPrefs.SetInt (stageName, 1);
		Application.LoadLevel ("JuggernautGet");
	}

	void GetVen()
	{
		DamageDetection.currentHealth = 28;
		PlayerPrefs.SetInt (stageName, 1);
		Application.LoadLevel ("VenomGet");
	}

	void WinScreen()
	{
		PlayerPrefs.SetInt (stageName, 1);
		Application.LoadLevel ("WinScreen");
	}
}
