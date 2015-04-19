using UnityEngine;
using System.Collections;

public class ScoringAlgorithm : MonoBehaviour {

	double storyScore;
	static double totalScore;

	void CalculateScore(int rating, double credibility){
		storyScore = rating * credibility;
		totalScore += totalScore = storyScore;
	}
}
