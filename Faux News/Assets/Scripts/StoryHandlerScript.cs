using UnityEngine;
using System.Collections;

public class StoryHandlerScript : MonoBehaviour {

	public StoryScript[] allStories;

	// Use this for initialization
	void Start () {
		allStories = GetComponentsInChildren<StoryScript> ();
	}

}
