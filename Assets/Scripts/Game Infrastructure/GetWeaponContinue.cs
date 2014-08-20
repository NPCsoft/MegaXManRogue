using UnityEngine;
using System.Collections;

public class GetWeaponContinue : MonoBehaviour {
	public float delay = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		if (delay > 1f)
			if (Input.anyKeyDown)
				Application.LoadLevel ("StageSelect");
	
	}
}
