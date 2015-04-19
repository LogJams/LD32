using UnityEngine;
using System.Collections;

public class NightlySlotScript : MonoBehaviour {

	public GameHandlerScript game;
	public int num;

	TextMesh text;
	BoxCollider2D box;
	float fieldWidth;

	string fullStory = "";
	string shortenedStory = "";

	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
		box = GetComponent<BoxCollider2D> ();
		fieldWidth = box.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = shortenedStory;
	}

	void OnMouseOver() {
		if (Input.GetButtonUp ("Fire1")) {
			//replace this story with a new one
			fullStory = game.getCurrentText(num);
			shortenStory ();
		}
	}

	public void setText(string txt) {
		fullStory = txt;
		shortenStory ();
	}

	void shortenStory() {
		text.text = fullStory;
		if (fullStory.Length > 0) {
			shortenedStory = fullStory;
			text.text = shortenedStory;
			int index = shortenedStory.Length;
			while (text.renderer.bounds.size.x > fieldWidth && index > 0) {
				index --;
				shortenedStory = fullStory.Substring(0, index);
				text.text = shortenedStory;
			}
			shortenedStory = fullStory.Substring(0, index) + "\n"
				+ fullStory.Substring (index, Mathf.Min (index, fullStory.Length - index)) + "\n"
					+ fullStory.Substring (index + Mathf.Min (index - 3, fullStory.Length - index), Mathf.Min (index - 3, fullStory.Length - 2*index)) + "...";
				
			text.text = shortenedStory;
		}
	}
}
