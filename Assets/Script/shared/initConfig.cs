using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string s = "{\"gameConfiguration\": {\"player\": {\"name\": \"Tatiana Flávia\"},\"supervisor\": {\"name\": \"Patrícia Maria\"}}}";
		string jsonString = "{\"name\":\"8484239823\",\"lives\":\"Powai\",\"health\":\"Random Nick\"}";
		RootConfiguration gc = JsonUtility.FromJson<RootConfiguration>(s);
		Debug.Log(gc.gameConfiguration.player.name);
	}

}
