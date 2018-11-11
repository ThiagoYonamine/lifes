using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleController : MonoBehaviour {

	public Text txt_question;
	public Text txt_optionA;
	public Text txt_optionB;
	public Text txt_optionC;
	public Text txt_optionD;

	private int idQuestion;
	private string[] questions;
	private string[] optionA;
	private string[] optionB;
	private string[] optionC;
	private string[] optionD;
	private char[] answers;
	private GameResult performance;

	public GameObject feedback;
	
 	void Awake(){
		Component[] componets = Settings.puzzle.game.components;
		int index = 0;
		foreach(Component component in componets){
			int opt=0;
			// TODO URGENT, each question need to be one component!!
			// Talk to back-end guys to change the JSON data
			int gameSize= component.resources.Length/5;
			questions = new string[gameSize];
			answers = new char[gameSize];
			optionA = new string[gameSize];
			optionB = new string[gameSize];
			optionC = new string[gameSize];
			optionD = new string[gameSize];
			foreach(Resource resource in component.resources){
				if (resource.role == "problem") questions[index] = resource.content;
				else{
					if(opt == 0) optionA[index] = resource.content;
					else if(opt == 1) optionB[index] = resource.content;
					else if(opt == 2) optionC[index] = resource.content;
					else if (opt == 3) optionD[index] = resource.content;
					if(resource.role == "answer")answers[index] =  (char)(int)(opt + 'A');
					opt++;
				}

				if(opt >= 4){
					opt = 0;
					index++;
				}
			}
		}
	}


	void Start () {
		feedback.SetActive(false);
		performance = new GameResult();
		performance.game = Settings.puzzle.game.id;
		performance.hits = 0;
		performance.fails = 0;
		idQuestion = 0;
		txt_question.text = questions[idQuestion];
		txt_optionA.text = optionA[idQuestion];
		txt_optionB.text = optionB[idQuestion];
		txt_optionC.text = optionC[idQuestion];
		txt_optionD.text = optionD[idQuestion];
	}

	public void answer(string option) {
		if (idQuestion < questions.Length) {
			if (option[0] == answers[idQuestion]) {
				performance.hits++;
			} else {
				performance.fails++;
			}
			
			nextQuestion ();
		}
	}
	private void nextQuestion(){
		idQuestion++;
		if (idQuestion >= questions.Length) {
			feedback.SetActive(true);
		}
		else {
			txt_question.text = questions[idQuestion];
			txt_optionA.text = optionA[idQuestion];
			txt_optionB.text = optionB[idQuestion];
			txt_optionC.text = optionC[idQuestion];
			txt_optionD.text = optionD[idQuestion];
		}
	}

	public void setFeelingRate(int stars){
		performance.feelingRate = stars;
		performance.score = performance.hits;
		JsonUtils jsonUtils = (new GameObject("jsonUtils")).AddComponent<JsonUtils>();
		jsonUtils.sendResponse(performance);
	}

}
