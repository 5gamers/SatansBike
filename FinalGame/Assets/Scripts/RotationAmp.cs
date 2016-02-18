using UnityEngine;
using System.Collections;

public class RotationAmp : MonoBehaviour {

	//rotação da ampulheta
	public int speed;
	public GameObject Amp;

	void Update () {
		Amp.transform.Rotate (0, 0, Time.deltaTime * speed);
		}
}
