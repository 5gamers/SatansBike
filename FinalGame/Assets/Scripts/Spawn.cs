using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Prefab;// Objeto q vai spawnar
	public float pos1;
	public float pos2;

	public float xFix;

	public float rateSpawn; // intevalo de spawn
	private float currentTime; //contador de tempo

	private GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		currentTime = 0;

		StartCoroutine (SpawnRunner ());
	}
	
	void LateUpdate () {
		Vector3 trans = player.transform.position;

		trans.x += xFix;

		if (Random.Range (0, 100) > 50)
			trans.y = pos1;
		else
			trans.y = pos2;
		
		transform.position = trans;
	}

	IEnumerator SpawnRunner()
	{
		yield return new WaitForSeconds (2f);
		while (true) {
				
			Instantiate (Prefab, transform.position, transform.rotation);

			yield return new WaitForSeconds (rateSpawn);
		}
	}

}

