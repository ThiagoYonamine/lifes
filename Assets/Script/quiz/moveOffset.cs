using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour {

	public float velocidade;
	private float offset;
	private Material materialAtual;

	// Use this for initialization
	void Start () {
		materialAtual = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += velocidade;
		materialAtual.SetTextureOffset ("_MainTex", new Vector2(offset,0));
		
	}
}
