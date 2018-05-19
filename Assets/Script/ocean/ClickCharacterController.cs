﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCharacterController : MonoBehaviour {
	// Fields
	Vector3 lastMovementVector;
	Vector3 currentPointToMoveTo;
	
	Vector3 clickScreenPosition;
	Vector3 clickWorldPosition;

	float slowingDistance = 7.0f;

	Vector3 desiredVelocity;

	float maxSpeed = .9f;
	private float angle;

	// Use this for initialization
	void Start(){
		currentPointToMoveTo = new Vector3(0, 0);
	}

	// Update is called once per frame
	void FixedUpdate(){
		// Retrive left click input

		if (Input.GetMouseButton(0)){
			// Retrive the click of the mouse in the game world
				clickScreenPosition = Input.mousePosition;
				currentPointToMoveTo = Camera.main.ScreenToWorldPoint (new Vector3 (clickScreenPosition.x, clickScreenPosition.y, 0));
				currentPointToMoveTo.z = 0;
		}

		//Vector3 force = (desiredVelocity - currentMovementVector);
		//currentMovementVector += force;
		transform.position = Vector3.MoveTowards(transform.position, currentPointToMoveTo, Time.deltaTime * maxSpeed);
		transform.position = Vector3.Lerp(transform.position, currentPointToMoveTo, Time.deltaTime * maxSpeed);

		// Flip pointing to the mouse
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){
			transform.localScale = new Vector3(1, -1, 1);
		}
		else{
			transform.localScale = new Vector3(1, 1, 1);
		}
	}
}