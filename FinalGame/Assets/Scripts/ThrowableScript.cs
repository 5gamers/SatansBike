using UnityEngine;
using System.Collections;

public class ThrowableScript : MonoBehaviour {

	private GameControllerScript gameController;

	void Start()
	{
		GameObject obj = GameObject.FindWithTag ("GameController");

		if (obj != null)
			gameController = obj.GetComponent<GameControllerScript> ();
	}
		

	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {

			PlayerController playerController = obj.GetComponent<PlayerController> ();

			gameController.SetGameOver2();
		}
	}
}
