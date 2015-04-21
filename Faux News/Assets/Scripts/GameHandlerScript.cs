using UnityEngine;
using System.Collections;

//this script handles the overall game state. It has the currently selected story, and it adjusts Status, Rating, And Crediblity when the stories are submitted
public class GameHandlerScript : MonoBehaviour {

	static int storiesPerWeek = 10;

	public StoryScript currentStory;

	public CredibilityScript cred;
	public RatingScript rat;
	public WorldStatusScript world;

	
	public StoryScript[] weeklyNews; //list of 10 stories being shown for the week
	public NightlySlotScript[] slots;

	StoryImportScript import;
	public StoryHandlerScript handler;

	public StoryScript[] storyReels;

	public Camera afterCam;
	public Camera[] cameras;
	public WrapUpScript wrapup;

	public TextMesh storyDisplay;

	int day = 0;

	// Use this for initialization
	void Start () {
		import = GetComponent<StoryImportScript> ();
		import.Load ();
		weeklyNews = new StoryScript[storiesPerWeek];
		slots = GetComponentsInChildren<NightlySlotScript> ();
		storyReels = handler.allStories;
		init ();
	}

	void init() {
		day++;
		if (world.GetAverage() < -0.25f) {
			Application.LoadLevel ("LoseScene");
		}
		if (day >= 5) {
			Application.LoadLevel ("WinScene");
		}
		for (int i = 0; i < weeklyNews.Length; i++) {
			weeklyNews[i] = null;
		}
		afterCam.enabled = false;
		StoryHolderScript[] newsStories = import.GetRandomStories (storyReels.Length);
		for (int i = 0; i < storyReels.Length; i++) {
			storyReels[i].SetStoryAll(newsStories[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		storyDisplay.text = "";
		if (currentStory != null) {
			storyDisplay.text += currentStory.storyText;
		}
		for (int i = 0; i < storiesPerWeek; i++) {
			int indexer = i;
			if (weeklyNews[indexer] != null)
				slots[i].setText(weeklyNews[indexer].getText ());
			else
				slots[i].setText ("");
		}
	}


	void switchToRecap() {
		for (int i = 0; i < cameras.Length; i++) {
			cameras[i].enabled = false;
		}
		afterCam.enabled = true;
		wrapup.WrapUp ();
	}


	
	public void nextWeek() {
		for (int i = 0; i < cameras.Length; i++) {
			cameras[i].enabled = true;
		}
		init (); //disables afterCam
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

	public string getCurrentText(int slot) {
		weeklyNews [slot] = currentStory;
		if (currentStory != null) {
			string txt = currentStory.getText ();
			currentStory = null;
			return txt;
		}
		return "";
	}

	void Submit() { //private method called when the submit button is pressed
		for (int i = 0; i < storiesPerWeek; i++) { //currently only accounts for things that aired, not unaired news
			rat.AdjustRating(weeklyNews[i].ratingEffect); //adjust rating for each show
			cred.AdjustCredibility(weeklyNews[i].credibility); //adjust credibility for each show
			world.adjustWorld(weeklyNews[i]);
		}
		switchToRecap ();
	}
}
