using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript: MonoBehaviour {

	// Use this for initialization


	public void SetGameOver (){
		SceneManager.LoadScene ("GameOver1");
	}

	public void SetGameOver2(){
		SceneManager.LoadScene ("GameOver2");
	}

	public void fase1(){
		SceneManager.LoadScene ("Fase1");
	}

	public void start (){
		SceneManager.LoadScene("Start");
	}
	public void fase2 (){
		SceneManager.LoadScene ("Fase2");
	}
	public void boss (){
		SceneManager.LoadScene ("Boss");
	}
	public void win (){
		SceneManager.LoadScene ("Win");
	}

}
