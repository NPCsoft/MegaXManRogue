using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform gotolocation;
	public float followdelay = 5f;
	public bool follow = false;
	public float followspeed = 5f;
	public float minlimitx = -15f;
	public float maxlimitx = 15f;

	// Use this for initialization
	void Start () {
		Invoke ("BeginFollow",followdelay);
	}
	
	// Update is called once per frame
	void Update () {
		if (follow)
		{
			if (gotolocation.position.x > transform.position.x + 0.5f)
			{
				if (transform.position.x < maxlimitx)
				{
					transform.Translate (Vector2.right * followspeed * Time.deltaTime);
				}
			}

			if (gotolocation.position.x < transform.position.x - 0.5f)
			{
			    if (transform.position.x > minlimitx)
				{
					transform.Translate (Vector2.right * -followspeed * Time.deltaTime);
				}
			}
		}

	
	}

	void BeginFollow()
	{
		follow = true;
	}
}
