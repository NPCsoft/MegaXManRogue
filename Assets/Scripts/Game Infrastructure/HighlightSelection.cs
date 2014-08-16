using UnityEngine;
using System.Collections;

public class HighlightSelection : MonoBehaviour {

	public GameObject highlight;

	void OnMouseOver()
	{
		highlight.renderer.enabled = true;
	}

	void OnMouseExit()
	{
		highlight.renderer.enabled = false;
	}
}
