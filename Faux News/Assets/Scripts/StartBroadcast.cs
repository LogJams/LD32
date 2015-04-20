using UnityEngine;
using System.Collections;

public class StartBroadcast : MonoBehaviour {

	public GameHandlerScript game;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		if (Input.GetButtonUp ("Fire1")) { //Left click
			if (game.RunNews() ) {
				Debug.Log("Yeah! News!");
	//			light.enabled = true;
			} else { //there was an error!
				Debug.Log ("Make sure there's no dead air!");
			}
		}
	}
}
