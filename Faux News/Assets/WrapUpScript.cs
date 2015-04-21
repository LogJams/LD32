using UnityEngine;
using System.Collections;

public class WrapUpScript : MonoBehaviour {

	public TextMesh score;
	public TextMesh events;
	public TextMesh ratCredChange;

	public RatingScript rate;
	public WorldStatusScript world;
	public CredibilityScript cred;

	public PictureScript photo;

	public GameHandlerScript game; //use this to get the stories of the week and their effects

	float scoreChange, credChange, ratingChange, stateChange; //calculate these in WrapUp?

	int storyIndex = 0;
	float storyRuntime = 5; //seconds
	float currentTime = 0;
	StoryScript[] storyList ;

	public void WrapUp() { //this will be called by the GameHandlerScript when the wrapup begins
		//clean up anything old

		//calculate scores

		//set nightly picture based on stories?
		photo.NewPicture ();
		score.text = "Score: " + Mathf.Round(rate.rating*10)/10f;
		storyList = game.weeklyNews;
		currentTime = storyRuntime;
		ratCredChange.text = "This Week's Rating and Credibility: " + "404";

		storyIndex = 0;

		events.text = "Events this week: \n\n\n\n    " + splitStory(storyList[storyIndex].storyText);
		storyIndex++;

	}
	void Update() { //scroll text, flash images, etc
		if (storyList != null) {
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) {
				storyIndex++;
				storyIndex = storyIndex % storyList.Length;
				currentTime = storyRuntime;
				events.text = "Events this week: \n\n\n\n    " + splitStory(storyList[storyIndex].storyText);
			}
		}
	}


	string splitStory(string story) {
		int maxChars = 40; //max chars per line
		int length = story.Length;
		int index = 1;
		while (length > maxChars) {
			int splitPoint = maxChars*index;
			while (splitPoint > (maxChars*(index-1)) && !story.Substring(splitPoint,1).Equals (" ")) {
				splitPoint --;
			}
			if (splitPoint == maxChars*(index-1)+1) {
				splitPoint = maxChars*index;
			}
			story = story.Insert(splitPoint, "\n   ");
			length -= 45;
		}
		return story;
	}
}
