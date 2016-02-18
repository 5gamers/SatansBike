using UnityEngine;
using System.Collections;

public class MuriloContact : MonoBehaviour {

	public int hitpoints;
	public float muriloExplosionForce;
	public float playerExplosionForce;

	private Rigidbody2D rb;
	private GameControllerScript gameController;

	public GameObject passarim;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		GameObject obj = GameObject.FindWithTag ("GameController");

		if (obj != null)
			gameController = obj.GetComponent<GameControllerScript> ();
	
	}
	
	void OnCollisionEnter2D(Collision2D col){
		GameObject obj = col.gameObject;
		if (obj.CompareTag ("Player")) {

			PlayerController playerController = obj.GetComponent<PlayerController> ();

			if (playerController.IsTilting ()) {
				hitpoints--;

				Debug.Log (hitpoints);

				if (hitpoints <= 0)
					Die ();

				AddImpactForce (rb, muriloExplosionForce);
				AddImpactForce (obj.GetComponent<Rigidbody2D>(), playerExplosionForce);
			}
			else
				gameController.SetGameOver2 ();
		}
	}

	

	void AddImpactForce(Rigidbody2D body, float explosionStrength)
	{
		Vector3 force = -body.velocity.normalized * explosionStrength;
		body.AddForce(force, ForceMode2D.Impulse);
	}

	void Die()
	{
		SpriteRenderer r = gameObject.GetComponentInChildren<SpriteRenderer> ();
		Animator a = gameObject.GetComponentInChildren<Animator> ();
		BoxCollider2D b = gameObject.GetComponent<BoxCollider2D> ();

		r.enabled = false;
		a.enabled = false;
		b.enabled = false;


		passarim.SetActive (false);

		StartCoroutine (ChangeScene ());
	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds (2.0f);
		gameController.win ();
	}

}
