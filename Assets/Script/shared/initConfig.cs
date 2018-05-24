using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class initConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = "Assets/Resources/test.txt";
		StreamReader reader = new StreamReader(path); 
		string json = reader.ReadToEnd();
		reader.Close();
		SessionResponse gc = JsonUtility.FromJson<SessionResponse>(json);

		//TODO split games 
		Configuration.plataform = gc.gameConfiguration.games[0];
		Configuration.puzzle = gc.gameConfiguration.games[0];
	}
}

public static class Configuration{
	public static Game plataform;
	public static Game quiz;
	public static Game puzzle;
}
