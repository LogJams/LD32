using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class StoryImportScript : MonoBehaviour {
	
	string path = "Assets/Stories/stories.txt";
	List<GameObject> stories = new List<GameObject> ();
	List<GameObject> givenStories = new List<GameObject> ();
	List<int> givenIndexList = new List<int>();
	public bool last = false;
	
	// Imports news stories from the stories.txt file and palces them each as
	// a StoryHandlerScript on a GameObject in an array of GameObjects
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
		// while line exists and is not the first line
		do{
			line = reader.ReadLine ();
			if(line != null && !first){
				GameObject obj = new GameObject();
				obj.AddComponent<StoryHolderScript> ();
				StoryHolderScript story = obj.GetComponent<StoryHolderScript> ();
				// split the line into substring segments
				string[] subs = line.Split ('|');
				
				// assign story variables
				text = subs[0];
				category = subs[1];
				int.TryParse(subs[2], out ratings);
				string[] worldStateS = subs[3].Split (',');
				for(int i = 0;  i < worldStateS.Length; i ++){
					int.TryParse (worldStateS[i], out worldState[i]);
				}
				int.TryParse (subs[4], out credibility);
				int.TryParse (subs[5], out index);
				string[] dependenciesS = subs[6].Split (',');
				for(int j = 0; j < dependenciesS.Length; j++){
					int.TryParse (dependenciesS[j], out dependencies[j]);
					//dependencies[j];
				}
				
				// set story variables
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
				
				// add the object to stories list
				Debug.Log (dependencies[0]);
				stories.Add (obj);
			}
			first = false;
		}while(line != null);
		
	}
	
	// returns an array of GameObjects that have StoryHandlerScript components
	// these components are used to populate the new stories for any given week
	public StoryHolderScript[] GetRandomStories(int numberToGet) {
		// if there are not enough stories, reduce the number of required stories
		// set script variable last to true, denoting that there are no more 
		// updates to be given
		if(numberToGet >= stories.Count){
			numberToGet = stories.Count -1;
			last = true;
		}
		StoryHolderScript[] returnObjects = new StoryHolderScript[numberToGet];
		GameObject obj;
		bool isStillDependent = false;
		// get random stories
		for (int i = 0; i < numberToGet; i++) {
			int index = Random.Range (0, stories.Count);
			obj = stories[index];
			// check dependencies, if the dependency is 0, no dependency exists
			int[] dependencies = obj.GetComponent<StoryHolderScript>().dependencies;
			// if this is the last set, ignore dependencies
			if(!last){
				for(int j = 0; j < dependencies.Length; j++){
					if(dependencies[j] != 0){
						if(!givenIndexList.Contains (dependencies[j])){
							isStillDependent = true;
							j = dependencies.Length;
						}
					}
				}
			}
			// if there are no remaining dependencies or this is the last set
			if(!isStillDependent){
				returnObjects[i] = obj.GetComponent<StoryHolderScript>();
				givenStories.Add (obj);
				givenIndexList.Add (obj.GetComponent<StoryHolderScript>().index);
				stories.RemoveAt(index);
			} else { // otherwise decrement count and search again
				i--;
			}
			
		}
		return returnObjects;
	}
	
}