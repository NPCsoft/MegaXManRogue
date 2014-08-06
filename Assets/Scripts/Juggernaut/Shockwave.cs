using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {

	public GameObject emptyShockwave;
	private float SpawnDistance = 0f;
	// Use this for initialization
	void Start () {
		transform.localScale = Juggernaut.staticjuggernautSprite.localScale;
		Destroy (gameObject,5.1f);
		InvokeRepeating ("SpawnShockwaves",0.2f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		SpawnDistance += Time.deltaTime;
	}

	void SpawnShockwaves()
	{
		if (transform.localScale.x > 0f)
			Instantiate(emptyShockwave,new Vector3 (transform.localPosition.x + SpawnDistance * 10, transform.localPosition.y, transform.localPosition.z),Quaternion.identity);
		else
			Instantiate(emptyShockwave,new Vector3 (transform.localPosition.x - SpawnDistance * 10, transform.localPosition.y, transform.localPosition.z),Quaternion.identity);

	
	}
}
