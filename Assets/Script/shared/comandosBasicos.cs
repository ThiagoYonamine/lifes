﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class comandosBasicos : MonoBehaviour {

	public void carregaCena(string nome){
		//Application.LoadLevel (nome);
		SceneManager.LoadScene (nome, LoadSceneMode.Single);
	}


}