using UnityEngine;
using System.Collections;

public class StoryHolderScript : MonoBehaviour {

	public string storyText; //the actual story text. It could also be stored in the TextMesh
	public float credibility; //credibility effect of the story in the range (-1, 1)
	public float ratingEffect; //this can either add to a % rating or to a total rating against fake stations or a score
	//we can store the world effects as an array with set positions, as a dictionary with name lookup, or as a list of variables
	//range of (-1, 1) added to the current country effects
	public int nAmericaEffect;
	public int sAmericaEffect;
	public int europeEffect;
	public int africaEffect;
	public int asiaEffect;
	public int oceaniaEffect;
	public int middleEastEffect;
	public int antarcticaEffect;
	
	public int index;
	public int[] dependencies;

}
