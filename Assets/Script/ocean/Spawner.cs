using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject feedback;
	private GameObject[] collectables;

	private float timer;
	private float respawnTime;

	private void createInstance(int index, int score){
		//TODO find another way to do this
		GameObject newPrefab = Instantiate(prefab) as GameObject;
		newPrefab.GetComponent<Collectable>().score = score;
		collectables[index] = newPrefab;
	}

	private IEnumerator loadImage(int index, string url){
		WWW www = new WWW(url);
		yield return www;
		// Create a texture in DXT1 format
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		www.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 10);
		collectables[index].GetComponent<SpriteRenderer>().sprite = spriteToUse;
		Debug.Log("Resource added"+ collectables[index].GetComponent<Collectable>().score);
		www.Dispose ();
		www = null;
	}

	private IEnumerator loadSound(int index, string url){
		WWW www = new WWW(url);
		yield return www;

		AudioClip wwwsound =  www.GetAudioClip(true,true);
		collectables[index].GetComponent<Collectable>().sound = wwwsound;
		Debug.Log("Sound added");
		www.Dispose ();
		www = null;
	}

	private void loadFeedback(string text){
		feedback.GetComponentInChildren<Text>().text = text;
	}
/*
	void Awake(){
		//int componentsLength = Configuration.plataform.mechanic.components.Length;
		
		GameComponent[] componets = Settings.plataform.game.components.Length;
		collectables = new GameObject[componets.Length];
		int index = 0;
		foreach(GameComponent component in componets){
			Debug.Log("Loading component: " + component.id);
			foreach(Resource resource in component.resources){
				createInstance(index, component.component.score);
				Debug.Log("Loading resource: " + resource.id + " type: " + resource.resourceType.name);
				switch (resource.resourceType.id){
					case 1: // Text
						loadFeedback(resource.content);
						break;
					case 2: // Image
						StartCoroutine(loadImage(index, resource.content));
						break;
					case 3: // Sound
						StartCoroutine(loadSound(index, resource.content));
						break;
					default:
						Debug.Log("Resource type not defined:" + resource.resourceType.name);
						break;
				}
			}
			index++;
		}
	 }*/

	 void Awake(){
		Component[] componets = Settings.plataform.game.components;
		collectables = new GameObject[componets.Length];
		int index = 0;
		foreach(Component component in componets){
			Debug.Log("Loading component: " + component.name);
			foreach(Resource resource in component.resources){
				createInstance(index, resource.score);
				Debug.Log("Loading resource: " + resource.id + " type: " + resource.resourceType.name);
				switch (resource.resourceType.name){
					case "Texto": // Text
						loadFeedback(resource.content);
						break;
					case "Imagem": // Image
						StartCoroutine(loadImage(index, resource.content));
						break;
					case "Áudio": // Sound
						StartCoroutine(loadSound(index, resource.content));
						break;
					default:
						Debug.Log("Resource type not defined:" + resource.resourceType.name);
						break;
				}
			}
			index++;
		}
	 }
	 
	 void Start() {
		 respawnTime = 5 ;
         timer = Time.time + 3;
 	}

	void FixedUpdate () {	
		if(ControllerPlataform.isCompleted) return;
		if(timer < Time.time){
			 //avoid null pointer
			 if( collectables != null && collectables.Length > 0){
				 int rand = Random.Range(0, collectables.Length);
				 //TODO fix the map size
			 	 Instantiate (collectables[rand],
				 new Vector3(Random.Range(-100, 100), Random.Range(-100, 100),0),
				 new Quaternion(0, 0 , 0, 0));
			 }
			 timer = Time.time + respawnTime;
		}
	}
}