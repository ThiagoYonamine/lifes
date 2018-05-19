using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class responder : MonoBehaviour {

	private int idTema;

	public Text pergunta;
	public Text infoResposta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;


	public string[] perguntas;
	public string[] alternativaA;
	public string[] alternativaB;
	public string[] alternativaC;
	public string[] alternativaD;
	public string[] corretas;

	private int idPergunta;
	private float acertos = 0;
	private float nota;
	private int questoes;
	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
		idPergunta = 0;
		questoes = perguntas.Length;
		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
		respostaD.text = alternativaD [idPergunta];

		infoResposta.text = "Pergunta " + (idPergunta+1).ToString() + " de " + questoes.ToString();
	}
	
	public void resposta(string alternativa){
		if (alternativa == corretas[idPergunta]) {
			acertos++;
		}

		proximaPergunta ();
	}

	void proximaPergunta(){
		idPergunta++;
		if (idPergunta >= questoes) {
			nota = 10 * (acertos / questoes);
			nota = Mathf.RoundToInt (nota);

			if ( nota > PlayerPrefs.GetInt ("nota" + idTema.ToString ())) {
				PlayerPrefs.SetInt ("nota" + idTema.ToString (), (int)nota);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int)acertos);
			}

			PlayerPrefs.SetInt ("notaTemp" + idTema.ToString (), (int)nota);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int)acertos);

			SceneManager.LoadScene ("nota", LoadSceneMode.Single);
		} else {
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
			int questoes = perguntas.Length;
			infoResposta.text = "Pergunta " + (idPergunta + 1).ToString () + " de " + questoes.ToString ();
		}
	}


}
