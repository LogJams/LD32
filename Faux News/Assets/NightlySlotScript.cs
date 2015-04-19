using UnityEngine;
using System.Collections;

public class NightlySlotScript : MonoBehaviour {

	public GameHandlerScript game;
	public int num;

	TextMesh text;
	BoxCollider2D box;

	string shortenedStory = "";

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = shortenedStory;
	}

	void OnMouseOver() {
		if (Input.GetButtonUp ("Fire1")) {
			//replace this story with a new one
			shortenedStory = game.getCurrentText(num);
		}
	}
}
