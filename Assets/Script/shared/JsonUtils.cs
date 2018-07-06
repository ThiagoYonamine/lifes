using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Teste{
	public string id;
	public string message;
}


public class JsonUtils {

	public void sendResponse(Performance performance, string game){
		StopSessionRequest response = new StopSessionRequest();
		GamePerformance gamePerformance = new GamePerformance();

		gamePerformance.performance = performance;
		gamePerformance.game = Configuration.plataform.name;
		gamePerformance.player = Configuration.player;
		gamePerformance.supervisor = Configuration.supervisor;

		response.gamePerformance = gamePerformance;
		Debug.Log("RESP: "+ gamePerformance.player);
		Debug.Log("RESP: "+ gamePerformance.player.name);
		Debug.Log("RESP: "+ response);
		string resp = JsonUtility.ToJson(response, true);

		Teste teste = new Teste();
		teste.id = "1";
		teste.message = "oi";

		Debug.Log("RESP: "+ JsonUtility.ToJson(response, true));
		StreamWriter writer = new StreamWriter("Assets/Resources/response.txt", true);
        writer.WriteLine(resp);
        writer.Close();

	}
}
