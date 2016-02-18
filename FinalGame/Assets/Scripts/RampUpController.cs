using UnityEngine;
using System.Collections;

public class RampUpController : MonoBehaviour {

	private EdgeCollider2D collider;

	void Start()
	{
		collider = GetComponent<EdgeCollider2D> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {

			PlayerController playerController = obj.GetComponent<PlayerController> ();

			if (playerController.IsTilting ())
				collider.enabled = true;
			else
				collider.enabled = false;
		}
	}
}
