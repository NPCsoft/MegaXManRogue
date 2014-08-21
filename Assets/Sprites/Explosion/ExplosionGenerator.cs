using UnityEngine;
using System.Collections;

public class ExplosionGenerator : MonoBehaviour {

	public GameObject boom;

	// Use this for initialization
	void OnEnable () 
	{
		InvokeRepeating("Instboom",0.1f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Instboom()
	{
		Instantiate (boom, new Vector3 (gameObject.transform.position.x + Random.Range (-3f,3f),
		                                gameObject.transform.position.y + Random.Range (-3f,3f),
		                                gameObject.transform.position.z + Random.Range (-3f,3f)), 
		             Quaternion.identity);
	}
}
