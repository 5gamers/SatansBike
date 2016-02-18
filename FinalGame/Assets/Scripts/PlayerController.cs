using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float maxSpeed;

	public float tilt;

	private float xMoviment;
	private bool wallCheck;
	private bool facingRight;
	private bool tilting;
	private bool isRiding;

	private Rigidbody2D rbPlayer;
	private Transform transformPlayer;

	public Animator animePlayer;





	void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
		transformPlayer = GetComponent<Transform> ();
		isRiding = false;
		facingRight = true;
		wallCheck = false;
	}
	

	void Update () {
		xMoviment = Input.GetAxis ("Horizontal");
		tilting = Input.GetButton ("Jump");
	}

	void FixedUpdate(){
		if (xMoviment != 0) {
			rbPlayer.AddForce (new Vector3 (xMoviment * speed, 0.0f, 0.0f));
			rbPlayer.velocity = new Vector3 (Mathf.Clamp (rbPlayer.velocity.x, -speed, speed), rbPlayer.velocity.y, 0.0f);
			isRiding = true;
			animePlayer.SetBool ("moving", isRiding);
			if (xMoviment > 0 && !facingRight)
				Flip ();
			else if (xMoviment < 0 && facingRight)
				Flip ();
		} else {
			isRiding = false;
			animePlayer.SetBool ("moving", isRiding);
		}

		if (tilting) {
			transformPlayer.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, tilt));
		} else {
			transformPlayer.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		tilt *= -1;
		transformPlayer.localScale = theScale;
	}

	public bool IsTilting()
	{
		return tilting;
	}

	public bool IsFacingRight()
	{
		return facingRight;
	}

	void OnTriggerStay2D()
	{
		wallCheck = true;
	}
	void OnTriggerExit2D()
	{
		wallCheck = false;
	}
}
