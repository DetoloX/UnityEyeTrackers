using UnityEngine;
using System.Collections;

public class RelocatePosition : MonoBehaviour {
	[Header("Barra de botones abajo")]
	public GameObject[] Botones;
	public Camera mainCamara;
	[Space(10)]
	[Header("Valores de posicion")]
	public float x = 0;
	[Tooltip("Valor contando ancho menos esto")]
	[ContextMenuItem("Reset", "resetTheValue")]
	public float yOffSet = 50.0f;
	private float y;
	[Space(10)]
	[Header("Imagen Der Menu")]
	public GameObject StatusStart;
	public GameObject StatusDie;
	public GameObject StatusNextPhase;
	// Use this for initialization


	public void DisableOption(int i){
		int x=0;
		foreach (GameObject boton in Botones) {
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

	void PosicionImagenMenu(){
		float x0, y0;


		var renderer = StatusNextPhase.GetComponent<Renderer>();
		float width = renderer.bounds.size.x;
		x0 =  (Screen.width / 2)  ;
		y0 = Screen.height  / 2;

		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3((float)x0, (float)y0));
		Vector3 vector3= mainCamara.ViewportToWorldPoint(v3Pos);

		StatusStart.transform.position = new Vector3 (vector3.x  , vector3.y, -1);
		StatusDie.transform.position = new Vector3 (vector3.x - width , -vector3.y, -1);
		StatusNextPhase.transform.position = new Vector3 (vector3.x - width , -vector3.y, -1);
	
	}




	private void ActivaMenu(){
		Vector2 direction = new Vector2 (x, y).normalized;
		y = Screen.height - yOffSet;
		
		PosicionImagenMenu ();
		ActivaInicio ();
	}
	private void RecolocarTodos(){
	
		
		float division = Screen.width / (Botones.Length + 1);
		float total = division;
		foreach (GameObject boton in Botones) {
			
			if (boton.GetComponent<SpriteRenderer> ().enabled) {
				var renderer = boton.GetComponent<Renderer> ();
				float width = renderer.bounds.size.x;
				x = total + (division / 2) - (width / 2);
				Vector3 v3Pos = mainCamara.ScreenToViewportPoint (new Vector3 ((float)x, (float)y));
				
				//	Vector3 v3Pos = new Vector3((float)x,(float)y, 0);
				total += division;

				Vector3 vector3 = mainCamara.ViewportToWorldPoint (v3Pos);
				boton.transform.position = new Vector3 (vector3.x, -vector3.y, -1);
			}


		}
	}




	void Start () { 
		ActivaMenu ();
		RecolocarTodos ();

	
		/*	Rect insetRect = textura.pixelInset;
			insetRect.x = total + (division/2) - (insetRect.width/2);
			textura.pixelInset = insetRect;
			total+=division;*/
		/*	var renderer = boton.GetComponent<Renderer>();
			float width = renderer.bounds.size.x;

			Vector3 vector = boton.transform.position;
			vector.x =  total + (division/2) - (width/2);
			boton.transform.position = vector;
			total+=division;*/

	}


	private void ToggleButtons(bool esActivado){
		foreach (GameObject var in Botones) {
			var.GetComponent<SpriteRenderer>().enabled = esActivado;
			var.GetComponent<Collider2D>().enabled = esActivado;
		}

	}
	public void ActivaTodos(){
		ToggleButtons (true);
		StatusStart.GetComponent<SpriteRenderer> ().enabled = true;
		StatusDie.GetComponent<SpriteRenderer> ().enabled = true;
		StatusNextPhase.GetComponent<SpriteRenderer> ().enabled = true;



	}

	public void DesactivaTodos(){
		ToggleButtons (false);
		StatusStart.GetComponent<SpriteRenderer> ().enabled = false;
		StatusDie.GetComponent<SpriteRenderer> ().enabled = false;
		StatusNextPhase.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void ActivaPerdedor(){
	//	ToggleButtons (true);
		DisableOption (1);
		RecolocarTodos ();
		StatusStart.GetComponent<SpriteRenderer> ().enabled = false;
		StatusDie.GetComponent<SpriteRenderer> ().enabled = true;
		StatusNextPhase.GetComponent<SpriteRenderer> ().enabled = false;

	}

	public void ActivaSiguienteFase(){
	//	ToggleButtons (true);
		DisableOption (0);
		RecolocarTodos ();
		StatusStart.GetComponent<SpriteRenderer> ().enabled = false;
		StatusDie.GetComponent<SpriteRenderer> ().enabled = false;
		StatusNextPhase.GetComponent<SpriteRenderer> ().enabled = true;

	}

	public void ActivaInicio(){
	//	ToggleButtons (true);
		DisableOption (1);
		RecolocarTodos ();
		StatusStart.GetComponent<SpriteRenderer> ().enabled = true;
		StatusDie.GetComponent<SpriteRenderer> ().enabled = false;
		StatusNextPhase.GetComponent<SpriteRenderer> ().enabled = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
