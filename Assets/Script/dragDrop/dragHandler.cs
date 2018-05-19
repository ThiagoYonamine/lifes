﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

	public static GameObject itemDrag;
	Vector3 startPosition;
	private Vector3 screenPoint;
	private bool done;

	void start(){
		done = false;

	}
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (!done) {
			itemDrag = gameObject;
			startPosition = transform.position;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if (!done) {
			screenPoint = Input.mousePosition;
			screenPoint.z = 1f; //distance of the plane from the camera
			transform.position = Camera.main.ScreenToWorldPoint (screenPoint);
		}
	
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		
		itemDrag = null;
		if (!done) {
			transform.position = startPosition;

		}

	}

	#endregion

	void OnCollisionEnter2D(Collision2D colisao) {
		string nameColide = "local_" + gameObject.name;
		if (colisao.gameObject.name == nameColide) {
			
			transform.position = colisao.transform.position;
			//print (colisao.transform.position);
			done = true;
		}
		//print ("aki2");
	}
		


}
