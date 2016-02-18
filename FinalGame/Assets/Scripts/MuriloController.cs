using UnityEngine;
using System.Collections;

public class MuriloController : MonoBehaviour {

	public Rigidbody2D RbMurilo;
	private float movimentoX;
	public float maxSpeed;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		movimentoX = 1;
		//GameObject Player = GameObject.FindWithTag ("Player");

	}

	// Update is called once per frame
	void FixedUpdate () {
		RbMurilo.velocity = new Vector2 (movimentoX * maxSpeed, RbMurilo.velocity.y);
		Vector3 posPlayer = Player.transform.position;
		transform.position = new Vector3 (transform.position.x, Player.transform.position.y + 0.8f, transform.position.z);
	}

	void OnTriggerEnter2D(){
		Debug.Log ("Perdeu playboy");
	}

	void OnTriggerExit2D(){
		Debug.Log ("saiu");
	}

	void OnTriggerStay2D(){
		Debug.Log ("Teste");
	}
}
