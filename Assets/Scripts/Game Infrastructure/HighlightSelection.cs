using UnityEngine;
using System.Collections;

public class HighlightSelection : MonoBehaviour {

	public GameObject highlight;

	void OnMouseEnter()
	{
		highlight.SetActive (true);
	}
	
}
