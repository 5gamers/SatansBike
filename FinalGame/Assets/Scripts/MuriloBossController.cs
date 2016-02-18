using UnityEngine;
using System.Collections;

public class MuriloBossController : MonoBehaviour {

	public bool facingRight;
	public bool attack;
	//public Animator anime;
	public float speed;

	public Transform posicaoInicial;
	public Transform posA;
	public Transform posB;
	public Transform posC;
	public Transform posE;
	public int idMovimento;
	public Transform objeto;
	private int rand;
	public bool randAssigned;

	public Rigidbody2D RbMuriloBoss;
	private float movimentoX;
	public float maxSpeed;
	private float startTime;
	private float journeyLength;

	float dist;
	float journey;



	void Movimento1(){
		idMovimento = 1;
		startTime = Time.time;
	}

	void Movimento2(){
		idMovimento = 2;
		startTime = Time.time;
	}

	// Use this for initialization
	void Start () {
		objeto.position = posicaoInicial.position;
		//anime = GetComponent<Animator> ();
		startTime = Time.time;
		journeyLength = Vector3.Distance (posA.position, posB.position);
		idMovimento = 1;
		rand = 1;
		movimentoX = 1;
		randAssigned = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//anime.SetBool ("attack", attack);
		RbMuriloBoss.velocity = new Vector2 (movimentoX * maxSpeed, RbMuriloBoss.velocity.y);

		if (idMovimento == 1) {
			if (rand == 1) {
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posA.position, posE.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posA.position, posE.position, journey);
				if (objeto.position == posE.position) {
					Movimento2 ();
				}
			} else if (rand == 2) {
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posB.position, posE.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posB.position, posE.position, journey);
				if (objeto.position == posE.position) {
					Movimento2 ();
				}
			} else {
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posC.position, posE.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posC.position, posE.position, journey);
				if (objeto.position == posE.position) {
					Movimento2 ();
				}
			}
		} else if (idMovimento == 2) {
			if (randAssigned == false) {
				rand = Random.Range (1, 4);
				randAssigned = true;
			}
			if (rand == 1) {
				Debug.Log ("Entrou 1");
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posE.position, posA.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posE.position, posA.position, journey);
				if (objeto.position == posA.position) {
					Movimento1 ();
					randAssigned = false;
				}
			} else if (rand == 2) {
				Debug.Log ("Entrou 2");
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posE.position, posB.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posE.position, posB.position, journey);
				if (objeto.position == posB.position) {
					Movimento1 ();
					randAssigned = false;
				}
			} else {
				Debug.Log ("Entrou 3");
				dist = (Time.time - startTime) * speed;
				journeyLength = Vector3.Distance (posE.position, posC.position);
				journey = dist / journeyLength;
				objeto.position = Vector3.Lerp (posE.position, posC.position, journey);
				if (objeto.position == posC.position) {
					Movimento1 ();
					randAssigned = false;
				}
			}
		}	
		Quaternion rotation = Quaternion.LookRotation (Vector3.forward, posE.position - transform.position);
		objeto.rotation = rotation;


	}
	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *=-1;
		transform.localScale = theScale;
	}
}
