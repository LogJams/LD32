using UnityEngine;
using System.Collections;

public class ScoringAlgorithm : MonoBehaviour {

	double storyScore;
	static totalScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CalculateScore(int rating, double credibility){
		storyScore = rating * credibility;
		totalScore += totalScore = storyScore;
	}
}
