#pragma strict

public var ratingAndCred : GUIText;
public var weeksEvents : GUIText;
public var weekScore : GUIText;

function Start () {
	ratingAndCred.text = "This week's ratings: stuff\n\nThis week's credibility score: things";
	weeksEvents.text = "Important events this week:\n\t - Kanye West does stuff";
	weekScore.text = "WEEK X SCORE: LOTS";
}

function Update () {

}

function OnMouseDown () {
//	Application.LoadLevel(1);
	Debug.Log("loaded");
}