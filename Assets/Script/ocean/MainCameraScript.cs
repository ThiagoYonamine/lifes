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
		Vector3 desiredPosition = player.transform.position + offset;
		//X limits
		if (player.transform.position.x > 104 || player.transform.position.x < -126 ) {
			desiredPosition.x = transform.position.x;
		}
		 
		if (player.transform.position.y > 54 || player.transform.position.y < -55 ) {
			desiredPosition.y = transform.position.y;
		}
		transform.position = Vector3.Lerp (transform.position, desiredPosition, Time.deltaTime * cameraSpeed);
	}
}
