using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quizController : MonoBehaviour {

	public Text txt_question;
	public Text txt_optionA;
	public Text txt_optionB;
	public Text txt_optionC;
	public Text txt_optionD;

	private List<string> questions = new List<string>();
	private List<string> optionA = new List<string>();
	private List<string> optionB = new List<string>();
	private List<string> optionC = new List<string>();
	private List<string> optionD = new List<string>();
	private List<char> answers = new List<char>();
	private int idQuestion;
	//private string[] questions;
	//private string[] optionA;
	//private string[] optionB;
	//private string[] optionC;
	//private string[] optionD;
	//private char[] answers;
	private GameResult performance;

	public GameObject feedback;
	
 	void Awake(){
		Component[] componets = Settings.quiz.game.components;
		foreach(Component component in componets){
			Debug.Log(component.name);
			Debug.Log(component.resources.Length);
			int opt=0;
			// TODO URGENT, each question need to be one component!!
			// Talk to back-end guys to change the JSON data
			foreach(Resource resource in component.resources){
				if (resource.role == "problem") {
					questions.Add(resource.content);
				} 
				else{
					if(opt == 0) optionA.Add(resource.content);
					else if(opt == 1) optionB.Add(resource.content);
					else if(opt == 2) optionC.Add(resource.content);
					else if (opt == 3) optionD.Add(resource.content);
					if(resource.role == "answer") answers.Add((char)(int)(opt + 'A'));
					opt++;
				}

				if(opt >= 4){
					opt = 0;
				}
			}
		}
	}


	void Start () {
		feedback.SetActive(false);
		performance = new GameResult();
		performance.game = Settings.quiz.game.id;
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
		if (idQuestion < questions.Count) {
			if (option[0] == answers[idQuestion]) {
				Debug.Log("Certo");
				performance.hits++;
			} else {
				Debug.Log("Errado");
				performance.fails++;
			}
			
			nextQuestion();
		}
	}
	private void nextQuestion(){
		idQuestion++;
		Debug.Log("Next" + idQuestion);
		if (idQuestion >= questions.Count) {
			feedback.SetActive(true);
		}
		else {
			txt_question.text = questions[idQuestion];
			txt_optionA.text = idQuestion < optionA.Count ? optionA[idQuestion] : "Nenhuma";
			txt_optionB.text = idQuestion < optionB.Count ? optionB[idQuestion] : "Nenhuma";
			txt_optionC.text = idQuestion < optionC.Count ? optionC[idQuestion] : "Nenhuma";
			txt_optionD.text = idQuestion < optionD.Count ? optionD[idQuestion] : "Nenhuma";
		}
	}

	public void setFeelingRate(int stars){
		performance.feelingRate = stars;
		performance.score = performance.hits;
		JsonUtils jsonUtils = (new GameObject("jsonUtils")).AddComponent<JsonUtils>();
		jsonUtils.sendResponse(performance);
	}

}
