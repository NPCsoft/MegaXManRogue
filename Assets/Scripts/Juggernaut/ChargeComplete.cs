using UnityEngine;
using System.Collections;

public class ChargeComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Juggernaut.juggerCharge = false;
			Juggernaut.juggerChargeComplete = true;
			Juggernaut.anim.Play ("WallCrash");
			Invoke ("TurnAndIdle", 0.2f);
		}
	}

	void TurnAndIdle()
	{
		Juggernaut.staticjuggernautSprite.localScale = new Vector3 (Juggernaut.staticjuggernautSprite.localScale.x * -1, Juggernaut.staticjuggernautSprite.localScale.y, Juggernaut.staticjuggernautSprite.localScale.z);
		Juggernaut.anim.Play ("Idle");
	}
	
}
