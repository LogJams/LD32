using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour {

	public string storyText; //the actual story text. It could also be stored in the TextMesh
	public float credibility; //credibility effect of the story in the range (-1, 1)
	public float ratingEffect; //this can either add to a % rating or to a total rating against fake stations or a score
	//we can store the world effects as an array with set positions, as a dictionary with name lookup, or as a list of variables
	//range of (-1, 1) added to the current country effects
	public float nAmericaEffect;
	public float sAmericaEffect;
	public float europeEffect;
	public float africaEffect;
	public float asiaEffect;
	public float oceaniaEffect;
	public float middleEastEffect;
	public float antarcticaEffect;

	TextMesh text;
	float textWidth;
	float scrollSpeed = 1; //units/second
	float resetX;
	bool repeat = false;
	public bool scroll = false;
	public Transform parent;
	BoxCollider2D box;

	StoryScript clone;
	StoryScript parentText;

	GameHandlerScript story;

	// Use this for initialization
	void Start () {
//		text.text = storyText;
		GameObject go = GameObject.FindGameObjectWithTag ("StoryHandler");
		story = go.GetComponent<GameHandlerScript> ();
		text = GetComponent<TextMesh> ();
		textWidth = text.renderer.bounds.size.x;
		resetX = parent.position.x + textWidth + 0.5f;
		box = GetComponent<BoxCollider2D> ();
		box.size = new Vector2 ((textWidth + 0.6f) * 10, text.renderer.bounds.size.y*10);
	}

	public void setParent(StoryScript parentText) {
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
				clone = go.GetComponent<StoryScript>();
				clone.setParent (this);
			} else if (newPos.x + textWidth < parent.position.x) {
			Destroy (this.gameObject);
			}
			transform.position = newPos;
		}
	}
}
