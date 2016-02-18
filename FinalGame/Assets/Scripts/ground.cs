using UnityEngine;
using System.Collections;

public class ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll){

		if (coll.CompareTag ("Throwable")) {
			Destroy (coll.gameObject);
		}
	}
}
