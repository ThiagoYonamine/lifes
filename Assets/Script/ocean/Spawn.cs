using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawn : MonoBehaviour {

	public GameObject prefab;
	private GameObject[] collectables;

	private float timer;
	private float respawnTime;

 	void Awake() {
		 respawnTime = 5 ;
         timer = Time.time + 3;
 	}

	private IEnumerator loadImage(int index, string url, int score){
		WWW www = new WWW(url);
		yield return www;
		// Create a texture in DXT1 format
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		www.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 10.0f);
		GameObject newPrefab = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		newPrefab.GetComponent<SpriteRenderer>().sprite = spriteToUse;
		newPrefab.GetComponent<Collectable>().score = score;
		//collectables.Add(newPrefab);
		collectables[index] = newPrefab;
		Debug.Log("Resource added"+ newPrefab.GetComponent<Collectable>().score);
		www.Dispose ();
		www = null;
	}

	void Start(){
		int componentsLength = Configuration.plataform.mechanic.components.Length;
		collectables = new GameObject[componentsLength];
		int index = 0;
		foreach(Component component in Configuration.plataform.mechanic.components){
			Debug.Log("Loading component: " + component.id);
			foreach(Resource resource in component.resources){
				Debug.Log("Loading resource: " + resource.name + " type: " + resource.type);
				switch (resource.type){
					case "image":
						StartCoroutine(loadImage(index, resource.url, component.score));
						break;
					case "audio":
						//TODO not yet implemented
						break;
					default:
						Debug.Log("Resource type not defined:" + resource.type);
						break;
				}
			}
			index++;
		}


	 }
	 
	// Update is called once per frame
	void FixedUpdate () {	
		if(timer < Time.time){
			 Debug.Log("collectables:" + collectables.Length);
			 //avoid null pointer
			 if( collectables != null && collectables.Length > 0){
				 int rand = Random.Range(0, collectables.Length);
				 Debug.Log("random: "+ rand);
			 	Instantiate (collectables[rand],
				 new Vector3(0,0,0), new Quaternion(0, 0 , 0, 0) );
			 }
			 timer = Time.time + 1;
		}
	}
}