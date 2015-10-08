using UnityEngine;
using System.Collections;

public class MenuInicio : MonoBehaviour {
	[Header("Barra de botones abajo")]
	public GameObject[] botones;
	public Camera mainCamara;
	[Space(10)]
	[Header("Valores de posicion")]
	public float yOffSet = 50.0f;
	public float yOffSetAbajo = 50.0f;
	private float x = 0;
	[Header("Botones Niveles")]
	public GameObject[] botonesNiveles;
	private float screenHeight;

	// Use this for initialization
	void Start () {
		ActivaMenu ();
		RecolocarTodosMenuAbajo ();
		RecolocarTodosMenuNiveles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ActivaMenu(){
	
		screenHeight = Screen.height;
		
	//	PosicionImagenMenu ();
	
	}

	public void DisableOption(int i){
		int x=0;
		foreach (GameObject boton in botones) {
			if(x == i){
				boton.transform.GetComponent<Collider2D> ().enabled = false;
				boton.transform.GetComponent<SpriteRenderer> ().enabled = false;
			}else{
				boton.transform.GetComponent<Collider2D> ().enabled = true;
				boton.transform.GetComponent<SpriteRenderer> ().enabled = true;	
			}
			
			x++;
		}
		
	}
	private void RecolocarTodosMenuNiveles(){
		
		float division = Screen.width / (botonesNiveles.Length);
		float total = division / 2;
		float yAux=0;
		foreach (GameObject boton in botonesNiveles) {
			if (boton.GetComponent<SpriteRenderer> ().enabled) {
				var renderer = boton.GetComponent<Renderer> ();
				float width = renderer.bounds.size.x * 100;
				float height = renderer.bounds.size.y;
				x = total ;
				yAux =  (Screen.height/2) - (height/2)+yOffSet;
				Vector3 v3Pos = mainCamara.ScreenToViewportPoint (new Vector3 ((float)x, (float)yAux));
				total += division;
				Vector3 vector3 = mainCamara.ViewportToWorldPoint (v3Pos);
				boton.transform.position = new Vector3 (vector3.x, -vector3.y, -1);
			}
		}
	}
	private void RecolocarTodosMenuAbajo(){
		float division = Screen.width / (botones.Length + 2);
		float total = division;
		float y = 0;
		foreach (GameObject boton in botones) {

			if (boton.GetComponent<SpriteRenderer> ().enabled) {

				var renderer = boton.GetComponent<Renderer> ();
				float width = renderer.bounds.size.x;
				x = total + (division / 2) - (width / 2);
				y =  screenHeight + yOffSetAbajo ; 
				Vector3 v3Pos = mainCamara.ScreenToViewportPoint (new Vector3 ((float)x, (float)y));
				//	Vector3 v3Pos = new Vector3((float)x,(float)y, 0);
				total += division;
				Vector3 vector3 = mainCamara.ViewportToWorldPoint (v3Pos);
				boton.transform.position = new Vector3 (vector3.x, -vector3.y, -1);
			}
		}
	}

}
