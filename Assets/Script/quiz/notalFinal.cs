using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class notalFinal : MonoBehaviour {

	private int idTema;
	public Text nota;
	public Text infoTema;
	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;

	private int notaF;
	private int acertos;
	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
		notaF = PlayerPrefs.GetInt ("notaTemp"+idTema.ToString());
		acertos = PlayerPrefs.GetInt ("acertosTemp"+idTema.ToString());
		nota.text = notaF.ToString ();
		infoTema.text = "Voce acertou " + acertos.ToString();

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		if (notaF == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);

		}
		else if (notaF >= 6) {
				estrela1.SetActive (true);
				estrela2.SetActive (true);
				estrela3.SetActive (false);

		}
		else if (notaF >= 2) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);

		}
			
	}

	public void jogarNovamente(){
		SceneManager.LoadScene ("T"+idTema.ToString(), LoadSceneMode.Single);
	}

}
