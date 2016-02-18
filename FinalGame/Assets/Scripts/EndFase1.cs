using UnityEngine;
using System.Collections;

public class EndFase1 : MonoBehaviour {

	private GameControllerScript gameController;
	private FadeInFadeOut fadeController;
	/*public Texture2D fadeTexture;
	public float fadeSpeed;
	private float alpha	= 1;
	private int fadeDir = -1;
	private int drawDepht = -1000;
	private bool fadeIn =true;
	private bool fadeOut = false;*/

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.FindWithTag ("GameController");


		if (obj != null) {
			gameController = obj.GetComponent<GameControllerScript> ();
		}
	
	}
	

	/*void OnGUI(){
		if (fadeIn) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepht;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
		}
		fadeIn = false;
		if (fadeOut) {
			alpha -= fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepht;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
		}
		fadeOut = false;
	}*/

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("Player")) {
			/*fadeOut = true;
			OnGUI ();*/
			gameController.fase2 ();
		}
	}
}
