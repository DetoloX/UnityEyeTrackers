using UnityEngine;
using System.Collections;

public class RecolocarPosicionesSalir : MonoBehaviour {
	[Header("Barra de botones")]
	public GameObject salir;
	public GameObject aceptar;
	public GameObject cancelar;
	public Camera mainCamara;
	[Space(10)]
	[Header("Valor opcional YOffSet")]
	[Tooltip("Valor contando alto menos esto")]
	[ContextMenuItem("Reset", "resetTheValue")]
	public float yOffSet = -10f;
	public float xOffSet = 0;
	private float yScreen;
	private float xScreen;

	// Use this for initialization
	void Start () {
		yScreen = Screen.height;
		xScreen = Screen.width;
		recolocarPosiciones();
		ActivarRepuesta (false);
	}

	private void recolocarPosiciones(){

		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3((float)xScreen + xOffSet, (float)yScreen + yOffSet));
		Vector3 vector3= mainCamara.ViewportToWorldPoint(v3Pos);


		float tamanioBoton = salir.GetComponent<Renderer> ().bounds.size.x / 2;
		salir.transform.position = new Vector3 (vector3.x - tamanioBoton  , -vector3.y +tamanioBoton , 2);
		aceptar.transform.position = new Vector3 (-vector3.x + tamanioBoton + xOffSet, -vector3.y + tamanioBoton, 2);
		cancelar.transform.position = new Vector3 (vector3.x  - tamanioBoton , -vector3.y + tamanioBoton, 2);

	}



	public void ActivarRepuesta(bool esActivado){
		// muestra cancelar acpetar y oculta el boton salir, o al reves
		aceptar.GetComponent<SpriteRenderer>().enabled = esActivado;
		aceptar.GetComponent<Collider2D>().enabled = esActivado;
		cancelar.GetComponent<SpriteRenderer>().enabled = esActivado;
		cancelar.GetComponent<Collider2D>().enabled = esActivado;

		salir.GetComponent<SpriteRenderer>().enabled = !esActivado;
		salir.GetComponent<Collider2D>().enabled = !esActivado;
		
	}
}
