using UnityEngine;
using System.Collections;

public class MoveObjeto : MonoBehaviour {
	//Variaveis para velocidade
	public float speed;
	private float x;


	//esta empinando
	private GameObject GameControlerPlayer;

	// Use this for initialization
	void Start () {
		GameControlerPlayer = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		x = transform.position.x;

		x += speed * Time.deltaTime; 

		transform.position = new Vector3 (x,transform.position.y,transform.position.z);
	



		if (x <= -4) 
		{
			Destroy (transform.gameObject);
		}
	

	}

	void OnTriggerEnter2D(){

		Debug.Log ("BATEU");

	}
}
