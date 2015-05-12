using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public GUISkin guiSkin;
	// Use this for initialization
	[Header("Textos arriba flotantes")]
	public GUIText textoDerArriba;
	public GUIText textoIzqArriba;

	[Header("Menu abajo, recolocar")]
	public RelocatePosition relocatePosition;


	private bool isNextPhase = false;
	private bool isStart = true;
	private bool isDie = false;
	private string txtIzq;
	private string txtDer;
	private string txtIzqHigh;
	private string txtDerHigh;
	private int nivel;

	
	private int ultimoValor=0;

	public string TextoDerArriba
	{
		get { return textoDerArriba.text; }
		set { textoDerArriba.text = value; }
	}
	
	public string TextoIzqArriba
	{
		get { return textoIzqArriba.text; }
		set { textoIzqArriba.text = value; }
	}


	public string TxtIzqHigh
	{
		get { return txtIzqHigh; }
		set { txtIzqHigh = value; }
	}
	
	public string TxtDerHigh
	{
		get { return txtDerHigh; }
		set { txtDerHigh = value; }
	}

	public int Nivel
	{
		get { return nivel; }
		set { nivel = value; }
	}

	public string TxtIzq
	{
		get { return txtIzq; }
		set { txtIzq = value; }
	}

	public string TxtDer
	{
		get { return txtDer; }
		set { txtDer = value; }
	}
	
	public bool IsDie
	{
		get { return isDie; }
		set { isDie = value; }
	}

	public bool IsStart
	{
		get { return isStart; }
		set { isStart = value; }
	}

	public bool IsNextPhase
	{
		get { return isNextPhase; }
		set { isNextPhase = value; }
	}

	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
	//	textoIzqArriba.text = TxtIzq;
	//	textoDerArriba.text = TxtDer;
	}
	private bool isShaking = false;
	private int valores=0;
	void OnGUI() {


		/*if(showScore){
			GUI.skin = guiSkin;
			string scoreString = score.ToString();// + " " +  PlayerPrefs.GetInt("numberOfChances").ToString();
			GUILayout.BeginArea(new Rect((Screen.width / 2)-30, 55, 80, 80));
			GUILayout.BeginHorizontal();
			GUILayout.Label(scoreString, "scoreLabelHigh");
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}*/
		
		if (isStart || isNextPhase || isDie) {//gameOver && !firstRun) {

			if (isStart && ultimoValor != 0) {
				relocatePosition.ActivaInicio ();
				ultimoValor = 0;
			}
			if (isNextPhase && ultimoValor != 1) {
				relocatePosition.ActivaSiguienteFase ();
				ultimoValor = 1;
			}
			if (isDie && ultimoValor != 2) {
				ultimoValor = 2;
				relocatePosition.ActivaPerdedor ();
			}
			GUI.skin = guiSkin;
			float aAlto = Screen.height;
			float aAncho = Screen.width;
			// area del menu LTWH
			// left top with heigh
			//LTWH left top with height
			if (!isStart){
				GUILayout.BeginArea (new Rect (50, 50, (aAncho - 100) / 2, aAlto - 100));
				GUILayout.BeginVertical ("Dot", GUILayout.Width ((aAncho - 100) / 2), GUILayout.Height ((aAlto - 100) / 2));


				if (isNextPhase) {
					//	GUILayout.Label ("Siguiente fase!!", "title");

				}
				if (isDie) {

					GUILayout.Label ("Destruye OVNIS", "title");
				}
				GUILayout.EndVertical ();
				GUILayout.EndArea ();
				// left, top, button, right


				GUILayout.BeginArea (new Rect ((aAncho) / 2, 50, (aAncho - 100) / 2, aAlto - 100));
				GUILayout.BeginVertical ("panelBlack", GUILayout.Width ((aAncho - 100) / 2), GUILayout.Height ((aAlto - 100) / 2));
				
				GUILayout.BeginHorizontal ();


				if (isStart)
					GUILayout.Label ("Comienza el juego", "title");
				if (isNextPhase)
					GUILayout.Label ("Siguiente fase!!", "title");
				if (isDie)
					GUILayout.Label ("Has perdido!!", "title");

				GUILayout.EndHorizontal ();
					
				GUILayout.BeginHorizontal ();
				GUILayout.Label ("Fase " + Nivel, "title");
				GUILayout.EndHorizontal ();
					
				GUILayout.Space (40);
					
				GUILayout.BeginHorizontal ();
					
				GUILayout.BeginVertical ();
				GUILayout.Label ("Tus puntos", "scoreLabelNow");
				GUILayout.EndVertical ();
					
				GUILayout.Space (10);
					
				GUILayout.BeginVertical ();
				GUILayout.Label ("Top", "scoreLabelHigh");
					
				GUILayout.EndVertical ();
					
				GUILayout.EndHorizontal ();
					
				GUILayout.BeginHorizontal ();
					
				GUILayout.BeginVertical ();
				GUILayout.Label (txtIzq, "scoreLabelNow");
				GUILayout.EndVertical ();
					
				GUILayout.Space (10);
					
				GUILayout.BeginVertical ();
				GUILayout.Label (txtIzqHigh, "scoreLabelHigh");
					
				GUILayout.EndVertical ();
					
				GUILayout.EndHorizontal ();
					
				GUILayout.BeginHorizontal ();
					
				GUILayout.BeginVertical ();
				GUILayout.Label (txtDer, "scoreLabelNow");
					
				GUILayout.EndVertical ();
					
				GUILayout.Space (10);
					
				GUILayout.BeginVertical ();
				GUILayout.Label (txtDerHigh, "scoreLabelHigh");
					
				GUILayout.EndVertical ();
					
				GUILayout.EndHorizontal ();

				GUILayout.Space (20);
					

					
				GUILayout.EndVertical ();
				GUILayout.EndArea ();
			}

		} else {
			if(ultimoValor >= 0){
				relocatePosition.DesactivaTodos();
				ultimoValor = -1;
			}
		


		}


		
		
		
	}
}
