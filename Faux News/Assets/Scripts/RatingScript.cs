using UnityEngine;
using System.Collections;

public class RatingScript : MonoBehaviour {
	
	public float rating = 50; //currently storing Rating as an int, either 100% rating or 1st place for the best
	TextMesh text;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Rating: " + (int)rating;
		rating += 1 * Time.deltaTime;
	}

	public void AdjustRating(float amt) {
		rating += amt;
	}
}
