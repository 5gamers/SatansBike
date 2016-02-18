using UnityEngine;
using System.Collections;

public class MovePlataform : MonoBehaviour {

	public Transform posicaoInicial;
	public Transform posA;
	public Transform posB;
	public Transform objeto;//eh a plataforma

	public int idMovimento;
	public float speed;
	private float startTime;
	private float journeyLength;


	void Movimento1()
	{
		idMovimento = 1;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posA.position, posB.position);
	}

	void Movimento2()
	{
		idMovimento = 2;
		startTime = Time.time;
		journeyLength = Vector3.Distance (posB.position, posA.position);
	}


	void Start () 
	{
		objeto.position = posicaoInicial.position;
		startTime = Time.time; //armazena o horario inicial do movimento
		journeyLength = Vector3.Distance(posA.position, posB.position);
		idMovimento = 1;
	
	}


	void FixedUpdate()
	{
		float dist = (Time.time - startTime) * speed;//tempo q leva pra percorrer a distancia
		float journey = dist / journeyLength;//quanto de movimento no tempo dist para concluir trajetoria (ida e volta)

		if (idMovimento == 1) 
		{
			objeto.position = Vector3.Lerp (posA.position, posB.position, journey);
			if (objeto.position == posB.position)
				Movimento2 ();
		}
		else if (idMovimento == 2) 
		{
			objeto.position = Vector3.Lerp (posB.position, posA.position, journey);
			if (objeto.position == posA.position)
				Movimento1 ();
		}



	}
	// Update is called once per frame
	void Update () {
	
	}
}

