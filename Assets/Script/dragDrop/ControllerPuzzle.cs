using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ControllerPuzzle : MonoBehaviour {

	public bool isCompleted;
	private static int pieces;
	private int totalPieces;
	public GameObject feedback;
	private GameResult performance;

	void Start () {
		pieces = 0;
		isCompleted = false;
		totalPieces = Settings.puzzle.game.components.Length;
		performance = new GameResult();
		//set plataform id
		performance.game = 2;
		performance.hits = 0;
		performance.fails = 0;
	}
	
	public static void completePiece(){
		pieces++;
		
	}

	void Update() {
		if(pieces/2 >= totalPieces && !isCompleted){
			showFeedback();
		}
	}

	void showFeedback(){
		isCompleted= true;
		/*GameObject feedbackMenu = PrefabUtility.InstantiatePrefab(feedback) as GameObject;
		feedbackMenu.GetComponentInChildren<Text>().text = "oi";//Settings.puzzle.gameComponents
		feedbackMenu.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);*/
		feedback.SetActive(true);

	}
	
	public void setFeelingRate(int stars){
		performance.feelingRate = stars;
		JsonUtils jsonUtils = (new GameObject("jsonUtils")).AddComponent<JsonUtils>();
		jsonUtils.sendResponse(performance);
	}
}
