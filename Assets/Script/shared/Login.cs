using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public InputField username;
	public InputField password;
	public string results;
	private string url = "http://lifes.dc.ufscar.br/hcgd-backend-teste/user/login/";

	public void Submit() {
		LoginRequest loginRequest = new LoginRequest();
		loginRequest.username = "norbteste";
		loginRequest.password = "senha123";
		Debug.Log("submit " + loginRequest.ToString());
		String json = "{\"username\": \"norbteste\", \"password\": \"senha123\"}";
        StartCoroutine(Post(url, json));
		
		//StartCoroutine(Post(url, obj));
		//StartCoroutine(Upload());
    }

 	IEnumerator Post(string url, string bodyJsonString) {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
 
        yield return request.SendWebRequest();
 
        Debug.Log("Status Code: " + request.responseCode);
		StringBuilder sb = new StringBuilder();
		foreach (System.Collections.Generic.KeyValuePair<string, string> dict in request.GetResponseHeaders()) {
			sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
		}

		// Print Headers
		Debug.Log(sb.ToString());
		// Print Body
		Debug.Log(request.downloadHandler.text.ToString());
		JSONObject json = new JSONObject(request.downloadHandler.text.ToString());
	
		

		if(json["user"]["player_datas"][0]["id"] != null){
			float id = json["user"]["player_datas"][0]["id"].n;
			Settings.userId = Convert.ToInt64(id);
			Debug.Log(Settings.userId);
			SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		}
    }


}
