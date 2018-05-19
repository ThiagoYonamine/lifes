using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDrag : MonoBehaviour {

	private bool done;

	void Start(){
		done = false;
	}

	void OnCollisionEnter2D(Collision2D colisao) {

			if (colisao.gameObject.name == "target") {
				Destroy (this.gameObject);
				colisao.gameObject.GetComponent<SpriteRenderer>().color =  Color.white;
			}
	}
}
