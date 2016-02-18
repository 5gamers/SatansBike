using UnityEngine;
using System.Collections;

public class BirdAtack : MonoBehaviour {
	public Transform cloaca;
	public float minWaitAtack;
	public float maxWaitAtack;
	public GameObject poo;
	void Start () {
		StartCoroutine (WhenCrap ());
	
	}

	IEnumerator WhenCrap()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (minWaitAtack, maxWaitAtack));
			Crap ();

		}
	}

	void Crap () {
		Instantiate (poo, cloaca.position, cloaca.rotation);
	}
	
	// Update is called once per frame

}
