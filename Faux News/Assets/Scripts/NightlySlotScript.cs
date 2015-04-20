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
		string summary = "";
		int index = 0;
		if (fullStory.Length > 0) {
			index = shortenString (fullStory);
			summary += fullStory.Substring(0, index);
			int remainingLength = fullStory.Length - index;
			if (remainingLength > 0) {
				string line2 = fullStory.Substring (index, remainingLength);
				index = shortenString (line2);
				summary += "\n" + line2.Substring (1, index-1); //remove the space at the beginning of this line
				remainingLength = line2.Length - index;
				if (remainingLength > 0) {
					string line3 = line2.Substring (index, remainingLength);
					index = shortenString (line3);
					Debug.Log (line3);
					summary += "\n" + line3.Substring (1, index-1); //remove the space at the beginnig of this line
				}
			}
		}
		shortenedStory = summary;
	}

	int shortenString(string fullVer) {
		string shortVer = fullVer;
		text.text = shortVer;
		int index = shortVer.Length;
		while (text.renderer.bounds.size.x > fieldWidth && index > 0) {
			index --;
			shortVer = fullVer.Substring(0, index);
			text.text = shortVer;
		}
		int index2 = Mathf.Max (shortVer.LastIndexOf (" "), 0);
		if (index2 > 1) {
			index = index2;
		}
		return index;
	}
}

























