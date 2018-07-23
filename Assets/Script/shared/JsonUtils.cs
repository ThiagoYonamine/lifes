using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonUtils {
	public void sendResponse(GameResult performance){
		performance.player = Settings.login.user.id;
		string resp = JsonUtility.ToJson(performance, true);
		StreamWriter writer = new StreamWriter("Assets/Resources/response.txt", true);
        writer.WriteLine(resp);
        writer.Close();
	}
}
