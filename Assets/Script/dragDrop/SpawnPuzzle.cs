using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
 
public class SpawnPuzzle : MonoBehaviour {

	public GameObject prefab;
	public GameObject prefabTarget;

	private IEnumerator loadImage(int index, string url, int score){
		WWW www = new WWW(url);
		yield return www;
		// Create a texture in DXT1 format
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		// assign the downloaded image to sprite
		www.LoadImageIntoTexture(texture);
		Rect rec = new Rect(0, 0, texture.width, texture.height);
		Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 1);
		
		//Where player need to drop image
		GameObject newPrefabTarget = PrefabUtility.InstantiatePrefab(prefabTarget) as GameObject;
		newPrefabTarget.transform.position = new Vector2(Random.Range(-440, 416), Random.Range(-253, -148));
		newPrefabTarget.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
	    newPrefabTarget.GetComponent<Image>().sprite = spriteToUse;
		newPrefabTarget.name = "target_obj" + index.ToString();

		//Initial image (draggable)
		GameObject newPrefab = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		newPrefab.transform.position = new Vector2(-425 + (index*(texture.width/2)), 243);
		newPrefab.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
	    newPrefab.GetComponent<Image>().sprite = spriteToUse;
		newPrefab.name = "obj" + index.ToString();

		www.Dispose ();
		www = null;
	}

	void Start(){
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
						//TODO not implemented yet
						break;
					default:
						Debug.Log("Resource type not defined:" + resource.type);
						break;
				}
			}
			index++;
		}
	}
	
}
