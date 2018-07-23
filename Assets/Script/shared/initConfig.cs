using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class initConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = "Assets/Resources/test3.txt";
		StreamReader reader = new StreamReader(path); 
		string json = reader.ReadToEnd();
		reader.Close();
		//SessionResponse gc = JsonUtility.FromJson<SessionResponse>(json);

 		string JSONToParse = "{\"configurations\":" + json + "}";
		Response gc= JsonUtility.FromJson<Response>(JSONToParse);
		Debug.Log(gc.configurations[0].id);
		Debug.Log(gc.configurations[0].game);
		Debug.Log(gc.configurations[0].gameComponents[0].id);

		//TODO split games 
		Settings.plataform = gc.configurations[0];

		//Configuration.plataform = gc.gameConfiguration.games[0];
		//Configuration.puzzle = gc.gameConfiguration.games[0];
		///Configuration.player = gc.gameConfiguration.player;
		//Configuration.supervisor = gc.gameConfiguration.supervisor;
	}
}
/*
public static class Configuration{
	public static Player player;
	public static Supervisor supervisor;
	public static Game plataform;
	public static Game quiz;
	public static Game puzzle;
	public static LoginWrapper login;
	public static Configuration plataform;
}
*/

public static class Settings{
	/*public static Player player;
	public static Supervisor supervisor;
	public static Game plataform;
	public static Game quiz;
	public static Game puzzle;*/
	public static LoginWrapper login;
	public static Configuration plataform;
}
