using UnityEngine;
using System.Collections;

public class AttackHandler : MonoBehaviour {

	public float spriteattacktimer = 0f;
	public float endspriteattacktimer = 1f;
	// Use this for initialization
	void OnEnable () {
		//Attack handler is used to keep the timer normalized throughout the combo
		Player.attacktimer = spriteattacktimer;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
