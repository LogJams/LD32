using UnityEngine;
using System.Collections;

public class ScrollText : MonoBehaviour {

	public Transform parent;
	
	TextMesh text;
	float textWidth;

	float scrollSpeed = 1; //units/second
	float resetX;
	bool repeat = false;
	public bool scroll = false;
	BoxCollider2D box;

	ScrollText clone;
	ScrollText parentText;

	StoryHandlerScript story;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("StoryHandler");
		story = go.GetComponent<StoryHandlerScript> ();
		text = GetComponent<TextMesh> ();
		textWidth = text.renderer.bounds.size.x;
		resetX = parent.position.x + textWidth + 0.5f;
		box = GetComponent<BoxCollider2D> ();
		box.size = new Vector2 ((textWidth + 0.6f) * 10, text.renderer.bounds.size.y*10);
	}

	public void setParent(ScrollText parentText) {
		this.parentText = parentText;
	}

	public string getText() {
		return text.text;
	}

	void OnMouseOver() {
		scroll = true;
		if (clone != null)
			clone.scroll = true;
		if (parentText != null)
			parentText.scroll = true;
		if (Input.GetButtonUp ("Fire1")) {
			story.currentStory = this; //set "selected story" somewhere to this story
		}
	}

	void OnMouseExit() {
		scroll = false;
		if (clone != null)
			clone.scroll = false;
		if (parentText != null)
			parentText.scroll = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (scroll) {
			Vector3 newPos = transform.position;
			newPos.x -= scrollSpeed * Time.deltaTime;
			if (newPos.x < parent.position.x && !repeat) {
				repeat = true;
				Vector3 npos = newPos;
				npos.x = resetX;
				GameObject go = (GameObject)Instantiate (this.gameObject, npos, Quaternion.identity);
				clone = go.GetComponent<ScrollText>();
				clone.setParent (this);
			} else if (newPos.x + textWidth < parent.position.x) {
			Destroy (this.gameObject);
			}
			transform.position = newPos;
		}
	}
}
