using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class temaJogo : MonoBehaviour {
	public Button btnPlay;
	public Text txtNomeTema;
	public GameObject infoTema;
	public Text txtInfoTema;
	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;



	public int numeroQuestoes;

	public string[] nomeTema;
	private int idTema;

	// Use this for initialization
	void Start () {
		idTema = 0;
		txtNomeTema.text = nomeTema [idTema];
		infoTema.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		txtInfoTema.text = "";
		btnPlay.interactable = false;
		
	}

	public void selecioneTema(int i){
		idTema = i;
		txtNomeTema.text = nomeTema [idTema];
		PlayerPrefs.SetInt ("idTema",idTema);
		int acertos =  PlayerPrefs.GetInt ("acertos"+idTema.ToString());
		int nota= PlayerPrefs.GetInt ("nota"+idTema.ToString());

		txtInfoTema.text = "Voce acertou "+ acertos.ToString() + " pergunta(s)";
		btnPlay.interactable = true;
		infoTema.SetActive (true);

		if (nota == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);

		}
		else if (nota >= 6) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);

		}
		else if (nota >= 2) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);

		}

	}

	public void jogar(){
		string level = "T"+idTema.ToString();
		//Application.LoadLevel (level);
		SceneManager.LoadScene (level, LoadSceneMode.Single);
	}
}
