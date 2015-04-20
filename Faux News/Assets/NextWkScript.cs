using UnityEngine;
using System.Collections;

public class NextWkScript : MonoBehaviour {
	
	public GameHandlerScript game;

	// Use this for initialization
	void OnMouseOver() {
		if (Input.GetButtonUp ("Fire1")) { //left click
			game.nextWeek();
		}
	}
}
