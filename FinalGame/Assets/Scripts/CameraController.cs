using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float yFix;
	public float xFix;

	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	void LateUpdate () {
		Vector3 pos = player.transform.position;
		pos.x += xFix;
		pos.x = Mathf.Clamp (pos.x, 0, 344.0f);
		pos.y = yFix;
		pos.z = -20;
		transform.position = pos;
	}
}
