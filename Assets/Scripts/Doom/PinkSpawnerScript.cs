using UnityEngine;
using System.Collections;

public class PinkSpawnerScript : MonoBehaviour {
	public GameObject Pink1;
	public Transform doomSprite;
	public Transform invertedTransformRotation;
	public float repinktimer = 2f;
	public float repinktimermax = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{	

		repinktimer += Time.deltaTime;


		if (repinktimer > repinktimermax){

			if (doomSprite.localScale.x == -1)
			{
				Instantiate (Pink1,this.transform.position,this.transform.rotation);
				repinktimer = 0f;
			}
			else
			{
				Instantiate (Pink1,invertedTransformRotation.transform.position,invertedTransformRotation.transform.rotation);
				repinktimer = 0f;
			}
		}
	
	}
}
