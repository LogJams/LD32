using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class StoryImportScript : MonoBehaviour {

	string path = "Assets/Stories/stories.txt";
	List<StoryScript> stories = new List<StoryScript> ();

	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader (path);
		string line = "";
		string text = "";
		string category = "";
		int ratings = 0;
		int[] worldState = {};
		int credibility = 0;
		int index = 0;
		int[] dependencies = {};
		do{
			line = reader.ReadLine ();
			if(line != null){
				StoryScript story = new StoryScript();
				string[] subs = splitString (line, '|');

				text = subs[0];
				category = subs[1];
				ratings = int.Parse ( subs[2]);
				string[] worldStateS = splitString (subs[3],',');
				for(int i = 0;  i < worldStateS.Length; i ++){
					worldState[i] = int.Parse (worldStateS[i]);
				}
				credibility = int.Parse (subs[4]);
				index = int.Parse (subs[5]);
				string[] dependenciesS = splitString (subs[6],',');
				for(int j = 0; j < dependenciesS.Length; j++){
					dependencies[j] = int.Parse (dependenciesS[j]);
				}

				story.storyText = text;
				story.credibility = credibility;
				story.ratingEffect = ratings;

				story.nAmericaEffect = worldState[0];
				story.sAmericaEffect = worldState[1];
				story.europeEffect = worldState[2];
				story.africaEffect = worldState[3];
				story.asiaEffect = worldState[4];
				story.oceaniaEffect = worldState[5];
				story.middleEastEffect = worldState[6];
				story.antarcticaEffect = worldState[7];

				story.index = index;
				story.dependencies = dependencies;

				stories.Add (story);
			}
		}while(line != null);

	}
	
	// Update is called once per frame
	StoryScript[] GetRandomStories(int numberToGet) {
		return null;
	}

	string[] splitString(string items, char delimiter){
		string[] results = items.Split(delimiter);
		return results;
	}
}
