﻿using System.Collections;
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
	private Performance performance;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
		performance = new Performance();
		scoreTransition = 10;
		score = 10;
		score_txt.text = score.ToString();
		textColor =  Color.yellow;
		isCompleted = false;
		performance.Hits = 0;
		performance.Fails = 0;
		performance.Time = 0;
		feedback.SetActive(false);
	}

	void FixedUpdate(){
		performance.Time += Time.deltaTime;
		if (score != scoreTransition && !isCompleted) {
			fontSize =  Mathf.Lerp(fontSize, 70, Time.deltaTime * 4);
			score = Mathf.Lerp(score, scoreTransition, Time.deltaTime * 3);
			textColor = Color.Lerp(textColor, Color.yellow, Time.deltaTime * 1);
			score_txt.text = Mathf.RoundToInt(score).ToString();
			score_txt.fontSize = Mathf.RoundToInt(fontSize);
			score_txt.color =  textColor;
		}
		if(score > 10 && !isCompleted){
			showFeedback();
		}
	}
	
	void showFeedback(){
		isCompleted= true;
		score_txt.text = "";
		//TODO why do i have many massages? 
		feedback.GetComponentInChildren<Text>().text = Configuration.plataform.feedbacks[0].message;
		feedback.SetActive(true);
	}

	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.tag == "food") {
			Debug.Log("score: " + colisao.gameObject.GetComponent<Collectable>().score);
			Debug.Log("SOUND");
			source.PlayOneShot(colisao.gameObject.GetComponent<Collectable>().sound, 1);

			int points = colisao.gameObject.GetComponent<Collectable>().score;
			scoreTransition +=  points;
			if(points < 0){
				textColor = Color.red;
				fontSize = 95;
				performance.Fails++;
			} else {
				textColor = Color.green;
				performance.Hits++;
			}
			Destroy (colisao.gameObject);
		} 
	}

	public void setFeelingRate(int points){
		performance.FeelingRate = points;
		Debug.Log("STOP: "+ performance.Time + " " + performance.FeelingRate + " " + performance.Fails);
	}
}
