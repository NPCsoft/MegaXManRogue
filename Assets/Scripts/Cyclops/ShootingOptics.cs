using UnityEngine;
using System.Collections;

public class ShootingOptics : MonoBehaviour {

	public float reshoottimer = 1f;
	public float reshoottimermax = 0.5f;
	public Transform origin;
	public GameObject OpticBlast;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		reshoottimer += Time.deltaTime;
		if (reshoottimer > reshoottimermax)
		{
			reshoottimer = 0f;
			Instantiate (OpticBlast, origin.localPosition, Quaternion.identity);
		}

	
	}
}
