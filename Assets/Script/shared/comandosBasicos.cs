using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class comandosBasicos : MonoBehaviour {

	public void carregaCena(string nome){
		SceneManager.LoadScene (nome, LoadSceneMode.Single);
	}

	public void quit(){
		  Application.Quit();
	}


}
