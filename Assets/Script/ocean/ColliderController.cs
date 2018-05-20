using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderController : MonoBehaviour {

	public Text score_txt;
	private int score;

	void Start(){
		score = 10;
		score_txt.text = score.ToString();
	}
	
	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.tag == "food") {
			Debug.Log("socore: " + colisao.gameObject.GetComponent<Collectable>().score);
			score += colisao.gameObject.GetComponent<Collectable>().score;
			score_txt.text = score.ToString();
			Destroy (colisao.gameObject);
		} 
	
	}
}
