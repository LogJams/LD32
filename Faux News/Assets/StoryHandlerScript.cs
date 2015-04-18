using UnityEngine;
using System.Collections;

public class StoryHandlerScript : MonoBehaviour {

	public ScrollText currentStory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentStory != null) {
			Debug.Log (currentStory.getText());
		}
	}
}
