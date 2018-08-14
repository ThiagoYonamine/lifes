using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.Networking;

public class initConfig : MonoBehaviour {

	public Text log;
	private string url = "http://lifes.dc.ufscar.br/hcgd-backend-teste/project/playergames/?user_id=";
	// Use this for initialization
	void Start () {
		
		/*string path = "Assets/Resources/test3.txt";
		
		StreamReader reader = new StreamReader(path); 
		string json = reader.ReadToEnd();
		reader.Close();
		//SessionResponse gc = JsonUtility.FromJson<SessionResponse>(json);
 		string JSONToParse = "{\"configurations\":" + json + "}";
		*/
		
		url = url + Settings.userId;
		Debug.Log("GET: " + url + Settings.userId);
		StartCoroutine(Get(url));
	
		//Configuration.plataform = gc.gameConfiguration.games[0];
		//Configuration.puzzle = gc.gameConfiguration.games[0];
		///Configuration.player = gc.gameConfiguration.player;
		//Configuration.supervisor = gc.gameConfiguration.supervisor;
	}

	IEnumerator Get(string url) {
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)  {
                Debug.Log(www.error);
				log.text = www.error;
            }
            else {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
				log.text = www.downloadHandler.text;
				string response = www.downloadHandler.text;
				string JSONToParse = "{\"configurations\":" + response + "}";
				//string objResponse =  response.Substring(1, response.Length-2);
				//Debug.Log(objResponse);
				Response gc= JsonUtility.FromJson<Response>(JSONToParse);

				//TODO split games 
				Settings.plataform = gc.configurations[0];
				Settings.puzzle = gc.configurations[0];
				Debug.Log("FOI: "+ gc.configurations[0]);
            }
        }
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
	public static long userId;
	public static LoginWrapper login;
	public static Configuration plataform;
	public static Configuration puzzle;
}
