using UnityEngine;
using System.Collections;

public class Murilo2Behavior : MonoBehaviour {

    public float speed;
    public float acceleration;
	private bool facingRight;
    public Transform spawn;

	public Animator anime;

	private bool going;

	private float lastXVelocity;

    private Rigidbody2D rb;
    private Vector3 target;
    private GameObject player;


	void Start()
    {
	    rb = GetComponent<Rigidbody2D>();

		anime = GetComponentInChildren<Animator> ();

        player = GameObject.FindWithTag("Player");
		facingRight = true;
		going = false;

		lastXVelocity = 0;

        StartCoroutine(Behavior());
	}

	void FixedUpdate()
    {
		Vector3 target;
		if (going)
			target = player.transform.position;
		else
			target = spawn.position;
		

		Vector3 targetDir = (target - transform.position);



		if (Vector3.Distance (target, transform.position) > 3.5f) {

			Quaternion rotation = Quaternion.LookRotation (Vector3.forward, targetDir - transform.position);
			transform.rotation = rotation;
			rb.AddForce (getForceTowards (targetDir), ForceMode2D.Force);

			anime.SetBool ("idle", false);
		} else if(Vector3.Distance (target, transform.position) > 1.0f) {
			rb.AddForce (getForceTowards (targetDir), ForceMode2D.Force);

			anime.SetBool ("idle", false);

		}  else {
			transform.rotation = Quaternion.Euler (Vector3.zero);
			rb.velocity = Vector3.zero;
			anime.SetBool ("idle", true);
		}
           
        


		if((facingRight && Sign(lastXVelocity) == -1) || (!facingRight && Sign(lastXVelocity) == 1))
			Flip();

		lastXVelocity = rb.velocity.x;
	}

    IEnumerator Behavior()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
			going = true;
            yield return new WaitForSeconds(3f);
			going = false;
            yield return new WaitForSeconds(5f);
        }
    }

	Vector3 getForceTowards(Vector3 targetDir)
	{
		Vector3 normalizedTargetDir = targetDir.normalized;

		Vector3 targetVelocity = normalizedTargetDir * speed;
		Vector3 deltaVelocity = targetVelocity - new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);

		return (deltaVelocity * acceleration);
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	int Sign(float value) {
		if (value > 0)
			return 1;
		else if (value < 0)
			return -1;
		else
			return 0;
	}
}
