using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

	private GameControllerScript gameController;
	private SpawnEnemies spawnEnemyScript;

	void Start()
	{

		GameObject obj = GameObject.FindWithTag ("GameController");


		if (obj != null) {
			gameController = obj.GetComponent<GameControllerScript> ();
			spawnEnemyScript = obj.GetComponent<SpawnEnemies> ();
		}
	}

	
	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {
			if (spawnEnemyScript.AllEnemiesDead ())
				gameController.boss ();
		}

	}
}
