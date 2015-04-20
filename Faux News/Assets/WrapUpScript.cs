using UnityEngine;
using System.Collections;

public class WrapUpScript : MonoBehaviour {

	public TextMesh score;
	public TextMesh events;
	public TextMesh ratCredChange;

	public RatingScript rate;
	public WorldStatusScript world;
	public CredibilityScript cred;

	public GameHandlerScript game; //use this to get the stories of the week and their effects

	float scoreChange, credChange, ratingChange, stateChange; //calculate these in WrapUp?

	public void WrapUp() { //this will be called by the GameHandlerScript when the wrapup begins
		//clean up anything old

		//calculate scores

		//set nightly picture based on stories?
	}


	void Update() { //scroll text, flash images, etc
		score.text = "Score: " + rate.rating;
		events.text = "Events this week: \nKanye West\nKanye West\nKanye West\nKanye West\nKanye West\nKanye West";
		ratCredChange.text = "This Week's Rating and Credibility: " + "404";
	}
}
