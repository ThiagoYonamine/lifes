using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SpawnerPuzzle : MonoBehaviour {
	public GameObject prefab;
	public GameObject prefabTarget;
	private GameObject[] objects;

	private void createInstance(int index, int score){
		//TODO find another way to do this
		GameObject newPrefab = Instantiate(prefab) as GameObject;
		newPrefab.GetComponent<Collectable>().score = score;
		objects[index] = newPrefab;
	}

	private IEnumerator loadImage(int index, string url){
		WWW www = new WWW(url);
		yield return www;
		// Create a texture in DXT1 format
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		www.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 1);
		
		//Where player need to drop image
		GameObject newPrefabTarget = Instantiate(prefabTarget) as GameObject;
		newPrefabTarget.transform.position = new Vector2(Random.Range(-440, 416), Random.Range(-253, -148));
		newPrefabTarget.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
	    newPrefabTarget.GetComponent<Image>().sprite = spriteToUse;
		newPrefabTarget.name = "target_obj" + index.ToString();

		//Initial image (draggable)
		//GameObject newPrefab = Instantiate(prefab) as GameObject;
		objects[index].transform.position = new Vector2(-425 + (index*(texture.width/2)), 243);
		objects[index].transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
	    objects[index].GetComponent<Image>().sprite = spriteToUse;
		objects[index].name = "obj" + index.ToString();

		www.Dispose ();
		www = null;
	}

	private IEnumerator loadSound(int index, string url){
		WWW www = new WWW(url);
		yield return www;

		AudioClip wwwsound =  www.GetAudioClip(true,true);
		objects[index].GetComponent<Collectable>().sound = wwwsound;
		Debug.Log("Sound added");
		www.Dispose ();
		www = null;
	}

	void Start() {
		int index = 0;
		Component[] componets = Settings.puzzle.game.components;
		objects = new GameObject[componets.Length];
		foreach(Component component in componets){
			Debug.Log("Loading component: " + component.name);
			foreach(Resource resource in component.resources){
				createInstance(index, resource.score);
				Debug.Log("Loading resource: " + resource.score);
				switch (resource.resourceType.name){
					case "Texto": // Text
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
	
}
