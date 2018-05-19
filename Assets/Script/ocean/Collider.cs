using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.tag == "food") {
			Destroy (colisao.gameObject);
		} 
	
	}
}
