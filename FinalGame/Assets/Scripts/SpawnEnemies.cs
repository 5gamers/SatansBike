using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public float spawnTime;

	public Transform spawnBird;
	public Transform spawnMushroom1;
	public Transform spawnMushroom2;

	public GameObject birdPrefab;
	public GameObject mushroomPrefab;
	public GameObject mushroomPrefab2;

	private GameObject[] enemies;


	void Start () {

		enemies = new GameObject[3];

		enemies[0] = Instantiate (birdPrefab, spawnBird.position, spawnBird.rotation) as GameObject;
		enemies[1] = Instantiate (mushroomPrefab, spawnMushroom1.position, spawnMushroom1.rotation) as GameObject;
		enemies[2] = Instantiate (mushroomPrefab2, spawnMushroom2.position, spawnMushroom2.rotation) as GameObject;
	}
	
	public void DisableMe (int id) {
		enemies[id].SetActive (false);
		StartCoroutine (RespawnObject (id));
	}

	IEnumerator RespawnObject(int id)
	{
		yield return new WaitForSeconds (spawnTime);
		enemies[id].SetActive (true);
	}

	public bool AllEnemiesDead()
	{
		for (int i = 0; i < enemies.Length; ++i) {
			if (enemies [i].activeSelf) {
				return false;
			}
		}

		return true;
	}
}
