using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class StoryImportScript : MonoBehaviour {

	string path = "Assets/Stories/stories.txt";
	List<GameObject> stories = new List<GameObject> ();

	List<GameObject> availableStories;

	// Use this for initialization
	public void Load () {
		StreamReader reader = new StreamReader (path);
		string line = "";
		string text = "";
		string category = "";
		int ratings = 0;
		int[] worldState = new int[8];
		int credibility = 0;
		int index = 0;
		int[] dependencies = new int[5];
		bool first = true;
		do{
			line = reader.ReadLine ();
			if(line != null && !first){
				GameObject obj = new GameObject();
				obj.AddComponent<StoryHolderScript> ();
				StoryHolderScript story = obj.GetComponent<StoryHolderScript> ();
				string[] subs = splitString (line, '|');

				text = subs[0];
				category = subs[1];
				int.TryParse(subs[2], out ratings);
				string[] worldStateS = splitString (subs[3],',');
				for(int i = 0;  i < worldStateS.Length; i ++){
					int.TryParse (worldStateS[i], out worldState[i]);
				}
				int.TryParse (subs[4], out credibility);
				int.TryParse (subs[5], out index);
				string[] dependenciesS = splitString (subs[6],',');
				for(int j = 0; j < dependenciesS.Length; j++){
					int.TryParse (dependenciesS[j], out dependencies[j]);
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

				stories.Add (obj);
				Debug.Log ("story");/*
				Debug.Log (story.storyText);// = text;
				Debug.Log (story.credibility);// = credibility;
				Debug.Log (story.ratingEffect);// = ratings;
				
				Debug.Log (story.nAmericaEffect);// = worldState[0];
				Debug.Log (story.sAmericaEffect);// = worldState[1];
				Debug.Log (story.europeEffect);// = worldState[2];
				Debug.Log (story.africaEffect);// = worldState[3];
				Debug.Log (story.asiaEffect);// = worldState[4];
				Debug.Log (story.oceaniaEffect);// = worldState[5];
				Debug.Log (story.middleEastEffect);// = worldState[6];
				Debug.Log (story.antarcticaEffect);// = worldState[7];
				Debug.Log (story.index);// = index;
				Debug.Log (story.dependencies);// = dependencies;*/
			}

			first = false;
		}while(line != null);
		availableStories = new List<GameObject> (stories); //copy stories
	}
	
	// Update is called once per frame
	public StoryHolderScript[] GetRandomStories(int numberToGet) {
		if (availableStories.Count < numberToGet)
			return null;
		StoryHolderScript[] holders = new StoryHolderScript[numberToGet];
		for (int i = 0; i < numberToGet; i++) {
			int rand = Random.Range (0, availableStories.Count);
			holders[i] = availableStories[rand].GetComponent<StoryHolderScript>();
			availableStories.RemoveAt (rand);
		}
		return holders;
	}

	string[] splitString(string items, char delimiter){
		string[] results = items.Split(delimiter);
		return results;
	}
}
