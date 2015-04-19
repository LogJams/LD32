using UnityEngine;
using System.Collections;

//this script handles the overall game state. It has the currently selected story, and it adjusts Status, Rating, And Crediblity when the stories are submitted
public class GameHandlerScript : MonoBehaviour {

	static int storiesPerWeek = 10;

	public StoryScript currentStory;

	public CredibilityScript cred;
	public RatingScript rat;
	public WorldStatusScript world;

	
	StoryScript[] weeklyNews; //list of 10 stories being shown for the week


	// Use this for initialization
	void Start () {
		weeklyNews = new StoryScript[storiesPerWeek];

	}
	
	// Update is called once per frame
	void Update () {
		if (currentStory != null) {
			Debug.Log (currentStory.getText());
		}
	}


	public bool RunNews() { //run this weeks news!
		for (int i = 0; i < storiesPerWeek; i++) {
			if (weeklyNews[i] == null) {
				return false;
			}
		}
		Submit (); //submit stories
		//adjust for penalties of not showing certain clips
		//find everything called "news clip" in scene, if it's not in WeeklyNews run a AdjustWorldNegative() on it? It could be slow

		return true;
	}

	void Submit() { //private method called when the submit button is pressed
		for (int i = 0; i < storiesPerWeek; i++) { //currently only accounts for things that aired, not unaired news
			rat.AdjustRating(weeklyNews[i].ratingEffect); //adjust rating for each show
			cred.AdjustCredibility(weeklyNews[i].credibility); //adjust credibility for each show
			world.adjustWorld(weeklyNews[i]);
		}
	}
}
