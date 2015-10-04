using UnityEngine;
using System.Collections;

public class STORYgamebuttongo : MonoBehaviour {
	
	public string levelname;
	public string levelname2;
	public AudioClip errorsound;
	public GameObject selectup = null;
	public GameObject selectdown = null;
	public GameObject selectleft = null;
	public GameObject selectright = null;
	public float controllerdelay = 1f;
	// Use this for initialization
	void OnEnable () {
		controllerdelay = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		controllerdelay += Time.deltaTime;
		if (controllerdelay > 0.2f){
			if (Input.GetButtonDown ("Dash") || Input.GetButtonDown ("Jump") || Input.GetButtonDown("Attack"))
			{
				if (PlayerPrefs.GetInt ("MagnetoLevel") == 1 && PlayerPrefs.GetInt ("JuggernautLevel") == 1 && PlayerPrefs.GetInt ("VenomLevel") == 1)
				{
					if (PlayerPrefs.GetInt("MisterSinisterLevel") == 1)
						Application.LoadLevel (levelname2);
					else
						Application.LoadLevel (levelname);
				}
				else
					GetComponent<AudioSource>().PlayOneShot (errorsound);
			}
			if (selectup != null)
			{
				if (Input.GetAxis ("Vertical") > 0f && Input.GetAxis ("Horizontal") == 0f)
				{
					selectup.SetActive (true);
				}
			}
			
			if (selectdown != null)
			{
				if (Input.GetAxis ("Vertical") < 0f && Input.GetAxis ("Horizontal") == 0f)
				{
					selectdown.SetActive (true);
				}
			}
			
			if (selectright != null)
			{
				if (Input.GetAxis ("Horizontal") > 0f && Input.GetAxis ("Vertical") == 0f)
				{
					selectright.SetActive (true);
				}
			}
			
			if (selectleft != null)
			{
				if (Input.GetAxis ("Horizontal") < 0f && Input.GetAxis ("Vertical") == 0f)
				{
					selectleft.SetActive (true);
				}
			}
			
			if (selectup != null && selectup.activeSelf || selectdown != null && selectdown.activeSelf || 
			    selectright != null && selectright.activeSelf || selectleft != null && selectleft.activeSelf)
				gameObject.SetActive (false);
		}
	}
}
