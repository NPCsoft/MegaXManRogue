using UnityEngine;
using System.Collections;

public class WallLeftChecker : MonoBehaviour {

	public int _count;
	
	// Use this for initialization
	void Start () {
		_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
			++_count;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
			Player.WallLeft = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall"){
			--_count;
		}
		if (_count == 0)
			Player.WallLeft = false;

	}
}
