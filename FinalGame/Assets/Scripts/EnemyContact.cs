using UnityEngine;
using System.Collections;

public class EnemyContact : MonoBehaviour {

	private GetId idScript;

	private GameControllerScript gameController;
	private SpawnEnemies spawnEnemyScript;

	void Start()
	{
		idScript = GetComponent<GetId> ();

		GameObject obj = GameObject.FindWithTag ("GameController");

		if (obj != null) {
			gameController = obj.GetComponent<GameControllerScript> ();
			spawnEnemyScript = obj.GetComponent<SpawnEnemies> ();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {

			PlayerController playerController = obj.GetComponent<PlayerController> ();

			if (playerController.IsTilting ())
				spawnEnemyScript.DisableMe (idScript.id);
			else
				gameController.SetGameOver2 ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {

			PlayerController playerController = obj.GetComponent<PlayerController> ();

			if (playerController.IsTilting () && playerController.IsFacingRight())
				spawnEnemyScript.DisableMe (idScript.id);
			else
				gameController.SetGameOver2 ();
		}
	}
}
