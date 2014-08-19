using UnityEngine;
using System.Collections;

public class BossKilled : MonoBehaviour {
	// Use this for initialization
	private string stageName;
	public GameObject currentBoss;
	public GameObject currentBoss2;
	void Start () {
		stageName = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	if (currentBoss == null && currentBoss2 == null)
		{
			PlayerPrefs.SetInt (stageName, 1);
			if (stageName != "DoomLevel")
				Invoke ("BackToStageSelect",5f);
			else
				Invoke ("WinScreen",5f);
		}
	}

	void BackToStageSelect()
	{
		DamageDetection.currentHealth = 28;
		Application.LoadLevel ("StageSelect");
	}
	void WinScreen()
	{
		Application.LoadLevel ("WinScreen");
	}
}
