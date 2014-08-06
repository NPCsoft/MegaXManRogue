using UnityEngine;
using System.Collections;

public class BossRoomWalls : MonoBehaviour {

	public float recrashtimer = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		recrashtimer += Time.deltaTime;
		if (recrashtimer > 5f && Juggernaut.juggerChargeComplete)
		{
			recrashtimer = 0f;
			gameObject.tag = "Enemy";
			transform.localPosition = Vector3.zero;
			Invoke ("Backtowall",1f);
		}
	
	}
	

	void Backtowall()
	{
		transform.localPosition = new Vector3 (0,1,0);
		gameObject.tag = "Player";
	}
}
