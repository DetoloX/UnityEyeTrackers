using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	
	public Camera mainCamara;
	public UDPReceive uDPReceive;
	private double x = 0;
	private double y = 0 ;
	private float witdhScreen, heightScreen;
	[Header("Caso especial, solo movimiento X")]
	public bool soloX = true;
	[Header("Posicion desde abajo mov solo X")]
	public float yOffset = 0.0f;

	[Header("Pos YOffSet Cursor")]
	public float yOffsetCursor = 0.0f;


	[Header("Navegacion Activa")]
	public bool navegaEnJuego = true;

	private EyeTribeTracker trackerAuxiliar = new EyeTribeTracker() ;

	private bool hayConexion = true;

	private float posX, posY, posBX, posBY;




	public bool HayConexion
	{
		get { return hayConexion; }
		set { hayConexion = value; }
	}

	void Start () {
		
		Vector3 stageDimensions = mainCamara.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,2));
		heightScreen = stageDimensions.y;
		witdhScreen = stageDimensions.x;
		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3(Screen.width/2, Screen.height/2,2));
		transform.position = mainCamara.ViewportToWorldPoint(v3Pos);

	}

	void OnGUI()
	{
		Rect rectObj=new Rect(40,10,200,400);
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.UpperLeft;
		try{

			GUI.Box (rectObj, "# XPrimero: " + x + "\n" +
			         "# XAnterior: " + trackerAuxiliar.AvgX + "\n" +
			         "# YPrimero: " + y + "\n" +
			         "# YAnterior: " + trackerAuxiliar.AvgY + "\n", style);
		
	}catch{
	}
}

	// variable para comprobar que no esta actualizando las variables de movimiento
	// se hace cada 50 frames para que no haga la comprobacion constantemente
	// esto tb es debido a que alguno eye trackers su tiempo de respuesta es mas lento
	// y puede producir que piense que no esta actualizando cuando en realidad si.
	int contador = 50;
	void FixedUpdate () {

		if (navegaEnJuego ||  (PlayerPrefs.GetInt ("Navegacion") == 1)) {



			try { 
				//	uDPReceive.eyeTracker.PrintInfo();

				if (uDPReceive.prueba != null) {
					x = uDPReceive.prueba.AvgX;
					y = uDPReceive.prueba.AvgY;

					if (contador <= 0) {
						try {
							
							if (uDPReceive.prueba.Comparar (trackerAuxiliar)) {
								HayConexion = false;
							} else {
								HayConexion = true;
							}
						} catch {
							trackerAuxiliar.AvgX = uDPReceive.prueba.AvgX;
							trackerAuxiliar.AvgY = uDPReceive.prueba.AvgY;
						}
						trackerAuxiliar.AvgX = uDPReceive.prueba.AvgX;
						trackerAuxiliar.AvgY = uDPReceive.prueba.AvgY;
						contador = 50;
					} else {
						contador --;
					}


					y += yOffsetCursor;
					if (soloX)
						y = Screen.height + yOffset;
					

				
				} else {
					HayConexion = false;
					x = 0;
					y = 0;
				
				}

			} catch {
				//		if(soloX)
				//			y = Screen.height - yOffset;
				x = 0;
				y = 0;
			}
		} else {
			x = 0;
			y = 0;
		}
		Move ();
	}
	

	void Move ()
	{
		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3((float)x, (float)y));
		Vector3 vector3= mainCamara.ViewportToWorldPoint(v3Pos);
		transform.position = new Vector3 (vector3.x, -vector3.y, -1);
	}
}
