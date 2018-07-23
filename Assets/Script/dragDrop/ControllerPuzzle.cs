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

	void Start () {
		pieces = 0;
		isCompleted = false;
		totalPieces = 1;//Configuration.puzzle.mechanic.components.Length;
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
		GameObject feedbackMenu = PrefabUtility.InstantiatePrefab(feedback) as GameObject;
		//TODO why do i have many massages? 
		feedbackMenu.GetComponentInChildren<Text>().text = "boa lek";//Configuration.plataform.feedbacks[0].message;
		feedbackMenu.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
	}
}
