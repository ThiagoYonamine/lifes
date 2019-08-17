using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class ControllerPlataform : MonoBehaviour {
	public static bool isCompleted;
	public Text score_txt;
	public GameObject feedback;
	private float score;
	private float scoreTransition;
	private float fontSize;
	private Color textColor; 
	private GameResult performance;
	private AudioSource source;
	private int MAX_SCORE = 30;

	void Start(){
		source = GetComponent<AudioSource>();
		performance = new GameResult();
		scoreTransition = 10;
		score = 10;
		score_txt.text = score.ToString();
		textColor =  Color.yellow;
		isCompleted = false;
		//set plataform id
		performance.game = 1;
		performance.hits = 0;
		performance.fails = 0;
		feedback.SetActive(false);
	}

	void FixedUpdate(){
		if (score != scoreTransition && !isCompleted) {
			fontSize =  Mathf.Lerp(fontSize, 70, Time.deltaTime * 4);
			score = Mathf.Lerp(score, scoreTransition, Time.deltaTime * 3);
			textColor = Color.Lerp(textColor, Color.yellow, Time.deltaTime * 1);
			score_txt.text = Mathf.RoundToInt(score).ToString();
			score_txt.fontSize = Mathf.RoundToInt(fontSize);
			score_txt.color =  textColor;
		}
		if(score > MAX_SCORE && !isCompleted){
			showFeedback();
		}
	}
	
	void showFeedback(){
		isCompleted= true;
		score_txt.text = "";
		//feedback.GetComponentInChildren<Text>().text = Configuration.plataform.feedbacks[0].message;
		feedback.SetActive(true);
	}

	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.tag == "food") {
			Debug.Log("score: " + colisao.gameObject.GetComponent<Collectable>().score);
			source.PlayOneShot(colisao.gameObject.GetComponent<Collectable>().sound, 1);

			int points = colisao.gameObject.GetComponent<Collectable>().score;
			scoreTransition +=  points;
			if(points < 0){
				textColor = Color.red;
				fontSize = 95;
				performance.fails++;
			} else {
				textColor = Color.green;
				performance.hits++;
			}
			Destroy (colisao.gameObject);
		} 
	}

	public void setFeelingRate(int stars){
		performance.feelingRate = stars;
		performance.score = (int) score;
		JsonUtils jsonUtils = (new GameObject("jsonUtils")).AddComponent<JsonUtils>();
		jsonUtils.sendResponse(performance);
	}
}
