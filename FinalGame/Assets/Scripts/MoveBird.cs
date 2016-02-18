using UnityEngine;
using System.Collections;

public class MoveBird : MonoBehaviour {


	private Transform tBird;
	private Rigidbody2D rbBird;
	private int movimentID;
	public float speed;
	private float startTime;
	private float journeyLength;
	private bool facingRight;

	private Transform posA;
	private Transform posB;



	void Movimento1 () {
		movimentID = 1;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posA.position, posB.position);
	}

	void Movimento2 () {
		movimentID = 2;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posB.position, posA.position);
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		tBird.localScale = theScale;
	}

	void Start () {
		rbBird = gameObject.GetComponent<Rigidbody2D> ();
		tBird = gameObject.GetComponent<Transform> ();

		GameObject obj = GameObject.Find ("PontoAbird");

		if (obj != null)
			posA = obj.GetComponent<Transform> ();

		GameObject obj2 = GameObject.Find ("PontoBbird");

		if (obj2 != null)
			posB = obj2.GetComponent<Transform> ();


		tBird.position = posB.position;
		startTime = Time.time; //armazena o horario inicial do movimento
		journeyLength = Vector3.Distance(posA.position, posB.position);
		movimentID = 2;
		facingRight = true;

	}


	void FixedUpdate () {
		float distance = (Time.time - startTime) * speed;//tempo q leva pra percorrer a distancia
		float journey = distance / journeyLength;//quanto de movimento no tempo dist para concluir trajetoria (ida e volta)

		if (movimentID == 1) {
			tBird.position = Vector3.Lerp (posA.position, posB.position, journey);
			if (tBird.position == posB.position) {
				Flip ();
				Movimento2 ();
			}
		}
		else if (movimentID == 2) {
			tBird.position = Vector3.Lerp (posB.position, posA.position, journey);
			if (tBird.position == posA.position) {
				Flip ();
				Movimento1 ();
			}
		}



	}
}
