using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
	public Transform player; 
	private Vector3 offset;
	private float cameraSpeed;
	// Use this for initialization
	void Start () {
		cameraSpeed = 1.5f;
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate() {
		//X limits
		if (player.transform.position.x < 410 && player.transform.position.x > -325 ) {
			Vector3 desiredPosition = player.transform.position + offset;
			transform.position = Vector3.Lerp (transform.position, desiredPosition, Time.deltaTime * cameraSpeed);
		}
		//TODO Y limits
	}
}
