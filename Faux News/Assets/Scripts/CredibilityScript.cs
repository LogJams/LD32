using UnityEngine;
using System.Collections;

public class CredibilityScript : MonoBehaviour {

	public float credibility = 0.7f; //percent out of 100.
	TextMesh text;

	
	// Update is called once per frame
	void Update () {
		//scale credibility to (-1, 1) in order to set the angle of the needle
		float rotation = -(credibility - 0.5f) * 2 * 90; //90 is worst, -90 is max
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rotation));
	}

	public void AdjustCredibility(float amt) {
		credibility += amt/100f;
	}
}
