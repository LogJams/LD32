using UnityEngine;
using System.Collections;

public class WorldStatusScript : MonoBehaviour {

	//states of each region ranging in (0, 1)
	public float nAmericaVal = 1;
	public float sAmericaVal = 1;
	public float europeVal = 1;
	public float africaVal = 1;
	public float asiaVal = 1;
	public float oceaniaVal = 1;
	public float middleEastVal = 1;
	public float antarcticaVal = 1;

	//static colors representing good and bad states
	static Color goodColor = new Color(1, 1, 1);//White, Unity uses the original sprite color
	static Color badColor = new Color(238/255f, 44/255f, 44/255f); //Firebrick red, converted from (0, 255) to (0, 1) scale

	//transforms used to acquire the sprite renderers
	Transform nAmerica, sAmerica, europe, africa, asia, oceania, middleEast, antarctica;
	SpriteRenderer nAmSp, sAmSp, euSp, afSP, asSp, ocSp, meSp, anSp;

	// Use this for initialization
	void Start () {
		//get the children sprites
		nAmerica = transform.FindChild ("North America");
		sAmerica = transform.FindChild ("South America");
		europe = transform.FindChild ("Europe");
		africa = transform.FindChild ("Africa");
		asia = transform.FindChild ("Asia");
		oceania = transform.FindChild ("Australia");
		middleEast = transform.FindChild ("Middle East");
		antarctica = transform.FindChild ("Antarctica");
		//get the children sprite's renderers
		nAmSp = nAmerica.GetComponent<SpriteRenderer> ();
		sAmSp = sAmerica.GetComponent<SpriteRenderer> ();
		euSp = europe.GetComponent<SpriteRenderer> ();
		afSP = africa.GetComponent<SpriteRenderer> ();
		asSp = asia.GetComponent<SpriteRenderer> ();
		ocSp = oceania.GetComponent<SpriteRenderer> ();
		meSp = middleEast.GetComponent<SpriteRenderer> ();
		anSp = antarctica.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Do a smooth Liner intERPolation between the good and bad colors
		nAmSp.color = Color.Lerp (badColor, goodColor, nAmericaVal);
		sAmSp.color = Color.Lerp (badColor, goodColor, sAmericaVal);
		euSp.color = Color.Lerp (badColor, goodColor, europeVal);
		afSP.color = Color.Lerp (badColor, goodColor, africaVal);
		asSp.color = Color.Lerp (badColor, goodColor, asiaVal);
		ocSp.color = Color.Lerp (badColor, goodColor, oceaniaVal);
		meSp.color = Color.Lerp (badColor, goodColor, middleEastVal);
		anSp.color = Color.Lerp (badColor, goodColor, antarcticaVal);

	}

	public void adjustWorld(StoryScript story) {
		nAmericaVal += story.nAmericaEffect;
		sAmericaVal += story.sAmericaEffect;
		europeVal += story.europeEffect;
		africaVal += story.africaEffect;
		asiaVal += story.asiaEffect;
		oceaniaVal += story.oceaniaEffect;
		middleEastVal += story.middleEastEffect;
		antarcticaVal += story.antarcticaEffect;
	}
}
