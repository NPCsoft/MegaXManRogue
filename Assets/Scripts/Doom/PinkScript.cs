using UnityEngine;
using System.Collections;

public class PinkScript : MonoBehaviour {
	public float verticalSpeed = 5f;
	public float horizontalSpeed = 1f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,5f);
	}
	
	// Update is called once per frame
	void Update () {
	
			transform.Translate (Vector2.up * -verticalSpeed * Time.deltaTime);
			transform.Translate (Vector2.right * -horizontalSpeed * Time.deltaTime);

	}
}
