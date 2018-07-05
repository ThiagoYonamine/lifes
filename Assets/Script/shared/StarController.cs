using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {
	public Sprite buttonOn;
	public Sprite buttonOff;
	void TurnOn () {
		this.gameObject.GetComponent<Button>().image.sprite = buttonOn;
	}

	void TurnOff (){
		this.gameObject.GetComponent<Button>().image.sprite = buttonOn;
	}
}
