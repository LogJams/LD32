using UnityEngine;
using System.Collections;

public class NextWkScript : MonoBehaviour {


	
	public GUIText ratingAndCred;
	public GUIText weeksEvents;
	public GUIText weekScore;
	public GameHandlerScript game ;


	// Use this for initialization
	void OnMouseOver() {
		if (Input.GetButtonUp ("Fire1")) { //left click
			game.nextWeek();
		}
	}
}
