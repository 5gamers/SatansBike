using UnityEngine;
using System.Collections;

public class mushroom : MonoBehaviour {

	private BoxCollider2D collider;

	private Animator anim;
	private float sum;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();

		sum = 0;
	}

	void Update(){
		sum += Time.deltaTime;
		float x = Mathf.Repeat (sum, 1);

		anim.SetFloat ("verticalMovement", x);

		if (x > 0.3333 && x < 0.6666)
			collider.enabled = true;
		else
			collider.enabled = false;
	}
}
