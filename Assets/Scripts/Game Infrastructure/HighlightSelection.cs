using UnityEngine;
using System.Collections;

public class HighlightSelection : MonoBehaviour {

	public GameObject highlight;
	public AudioClip selectionTone;

	void OnMouseEnter()
	{
		highlight.renderer.enabled = true;
		audio.PlayOneShot (selectionTone);
	}

	void OnMouseExit()
	{
		highlight.renderer.enabled = false;
	}
}
