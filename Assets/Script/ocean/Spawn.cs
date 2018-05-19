using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

 	public GameObject[] prefabs;
	public Rigidbody2D[] food_rb;
	public Sprite newS;
	private float timer;
	private float respawnTime;

		// The source image
	private string url = "http://www.hazteveg.com/img/icons/food/strawberry-icon.png";

 	void Awake() {
		 respawnTime = 5 ;
         timer = Time.time + 3;
 	}


	IEnumerator  Start(){
		WWW www = new WWW(url);
		yield return www;
		// Create a texture in DXT1 format
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		www.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 10.0f);
		prefabs[0].GetComponent<SpriteRenderer>().sprite = spriteToUse;
		www.Dispose ();
		www = null;
	 }


	// Update is called once per frame
	void FixedUpdate () {	
	
		if(timer < Time.time){
			 Instantiate (prefabs[0], new Vector3(0,0,0), new Quaternion(0, 0 , 0, 0) );
			 timer = Time.time + respawnTime;
		}
	}
}
