using UnityEngine;
using System.Collections;

public class ScoringAlgorithm : MonoBehaviour {

	double storyScore;
	static double totalScore;
	int totalRating;
	double totalCredibility;

	void CalculateScore(int rating, double credibility){
		totalRating += totalRating + rating;
		totalCredibility += totalCredibility + credibility;
		storyScore = rating * credibility;
		totalScore += totalScore = storyScore;
	}
}
