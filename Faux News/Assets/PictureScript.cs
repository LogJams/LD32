using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PictureScript : MonoBehaviour {

	public List<Sprite> images;

	SpriteRenderer r;

	void Start() {
		r = GetComponent<SpriteRenderer> ();
	}

	public void NewPicture() {
		int i = Random.Range (0, images.Count);
		r.sprite = images[i];
		images.RemoveAt (i);;
	}
}
