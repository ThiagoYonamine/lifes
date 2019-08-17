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

	public GameObject gameQuiz;
	public GameObject gamePuzzle;
	public GameObject gamePlataform;

	void Start () {
		gameQuiz.SetActive(false);
		gamePuzzle.SetActive(false);
		gamePlataform.SetActive(false);
		url = url + Settings.userId;
		Debug.Log("GET: " + url + Settings.userId);
		StartCoroutine(Get(url));
	}

	IEnumerator Get(string url) {
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)  {
				log.text = www.error;
				Debug.Log(www.error);
            }
           
		/*  TEST LOCAL */
		string path = "Assets/Resources/test4.txt";
		StreamReader reader = new StreamReader(path); 
		string json = reader.ReadToEnd();
		reader.Close();
		string JSONToParse = "{\"configurations\":" + json + "}";
		/*################*/

        /* REPONSE FROM SERVER */
		//log.text = www.downloadHandler.text;
		//string response = www.downloadHandler.text;
		//Test Request
		//string JSONToParse = "{\"configurations\":" + response + "}";
        /* ################ */
				Debug.Log(JSONToParse);
				Response gc= JsonUtility.FromJson<Response>(JSONToParse);

				for(int i=0; i<gc.configurations.Length; i++) {
					Debug.Log("init: " + gc.configurations[i].game.name);
					switch (gc.configurations[i].game.name) {	
						case "Perguntas":
							Settings.quiz = gc.configurations[i];
							gameQuiz.SetActive(true);
							break;
						case "Encaixe":
							Settings.puzzle = gc.configurations[1];
							gamePuzzle.SetActive(true);
							break;
						case "Coleta":
							Settings.plataform = gc.configurations[2];
							gamePlataform.SetActive(true);
							break;
					}
				}
        }
    }
}


public static class Settings{
	public static long userId;
	public static LoginWrapper login;
	public static Configuration plataform;
	public static Configuration puzzle;
	public static Configuration quiz;
}
