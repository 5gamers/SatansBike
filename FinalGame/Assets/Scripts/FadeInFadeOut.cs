using UnityEngine;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {

	public Texture2D fadeTexture;
	public float fadeSpeed;
	private float alpha	= 1;
	private int fadeDir = -1;
	private int drawDepht = -1000;

	void Update(){


	}

	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepht;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
		}
	public int beginFade(int dir){
		fadeDir = dir;
		return(fadeDir);
	}
	void OnLevelWasLoaded(){
		beginFade (-1);
	}


	
	
	


		/*void OnTriggerEnter2D(Collider2D col){
		if(col.tag ==("Player")){
			fadeOut = true;
			OnGUI ();
		}*/
	
		 


}
