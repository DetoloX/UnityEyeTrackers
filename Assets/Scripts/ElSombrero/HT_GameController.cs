using UnityEngine;
using System.Collections;

public class HT_GameController : MonoBehaviour {


	[Header("Controlador movimiento sombrero")]
	public MoveObject hatMoveController;

	[Header("Controlador  sombrero")]
	public SombreroController hatController;
	[Header("Controlador Menu")]
	public Menu menu;
	[Header("Tiempo Spawner")]
	public float SpawnTime = 0.5f;
	[Header("Escala aumento de los ovnis")]
	public float prefabsScale= 1.5f;
	[Header("Objetos")]
	public GameObject[]  balls;
	[Header("Posicion objetos")]
	public GameObject[]  caidas;
	[Header("Controlador aim para deshabilitarlo")]
	public AimController aimController;
	private Camera cam;
	private int numeroPelotas = 0;
	private static int numeroFallos = 3;
	private int numeroVidas = numeroFallos;
	private int numeroDeFase = 1;

	[Header("Numero puntos para pasar de fase")]
	public int numeroAciertos = 1;
	private int numberLevel = 0;
	private float maxWidth;
	private bool counting;
	
	public int NumeroPelotas
	{
		
		get { return numeroPelotas; }
		set { numeroPelotas = value; }
	}
	public int NumeroVidas
	{
		get { return numeroVidas; }
		set { numeroVidas = value; }
	}
	public int NumeroFallos
	{
		get { return numeroFallos; }
		set { numeroFallos = value; }
	}

	public int NumeroAciertos
	{
		get { return numeroAciertos; }
		set { numeroAciertos = value; }
	}

	public void TocoBomba(){
		numeroVidas--;
		menu.TextoDerArriba = "Vidas: \n" + numeroVidas;
		if (numeroVidas == 0) {
			IsDie (true);
		}
	}

	public int LevelNumber(){
		return numberLevel;
	}

	public void TocoPelota(){

		numeroPelotas++;
		menu.TextoIzqArriba = "Puntos: \n" + numeroPelotas;
		//menu.TxtDer = "Vidas: /n" + numeroVidas;
		if (numeroPelotas % numeroAciertos == 0) {
			IsNextPhase(true);
		}

	}

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		ActualizarRecords ();
		menu.TextoDerArriba = "Vidas: \n" + numeroVidas;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,2));
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
	}

	void FixedUpdate () {

		/*if (counting) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
		}*/

	}

	public void IsStart (bool activar) {

		ActualizarRecords ();
		menu.IsStart = activar;
	

		if (activar) {

			hatController.Deshabilitarlo();
			aimController.Habilitarlo();

			menu.IsStart = true;
			StopAllCoroutines ();
		} else {
			aimController.Deshabilitarlo();
			hatController.Habilitarlo();
			QuitarMenu();
			StartCoroutine (Spawn ());
		}

	}

	private void QuitarMenu(){
		menu.IsStart = false;
		menu.IsNextPhase = false;
		menu.IsDie = false;
	}

	public void IsNextPhase (bool activar) {

		SpawnTime -= 0.5f;
		if (SpawnTime <= 1) {
			SpawnTime = 1f;
		}

		if (activar) {
			EliminarTodosObjetos();
			hatController.Deshabilitarlo();
			aimController.Habilitarlo();
			numberLevel++;
			ActualizarRecords ();
			menu.IsNextPhase = true;
			StopAllCoroutines ();
		} else {
			aimController.Deshabilitarlo();
			hatController.Habilitarlo();
			QuitarMenu();
			StartCoroutine (Spawn ());
		}
	}

	public void IsDie (bool activar) {
		ActualizarRecords ();
		ReseteaRecords ();
		if (activar) {
			EliminarTodosObjetos();
			hatController.Deshabilitarlo();
			aimController.Habilitarlo();
			menu.IsDie = true;
			StopAllCoroutines ();
		} else {
			aimController.Deshabilitarlo();
			hatController.Habilitarlo();
			StartCoroutine (Spawn ());
			QuitarMenu();
		}
	}

	public void EliminarTodosObjetos(){
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject game in gameObjects) {
			Destroy(game);
		}
		
		gameObjects = GameObject.FindGameObjectsWithTag ("Friend");
		foreach (GameObject game in gameObjects) {
			Destroy(game);
		}
		
	}

	// resetea los datos para que vuelva a iniciar el juego..
	private void ReseteaRecords(){
		numeroVidas = numeroFallos;
		numeroPelotas = 0;
	}

	private void ActualizarRecords(){
	
		int puntos;
		puntos = PlayerPrefs.GetInt("SombreroPoints");
		// actualizamos los records
		if(numeroPelotas > puntos)
			PlayerPrefs.SetInt("SombreroPoints", numeroPelotas);

		
	
		puntos = PlayerPrefs.GetInt("SombreroPoints");
		
		menu.TxtIzqHigh = "Puntos: \n " + puntos;
		menu.TxtIzq = "Puntos: \n " + numeroPelotas;
		menu.Nivel = numberLevel;
	}

	private IEnumerator Spawn () {
		/*
		yield return new WaitForSeconds (2.0f);
		gameOverText.GetComponent<GUIText>().text =  "Nivel " + numeroDeFase;
		yield return new WaitForSeconds (SpawnTime);*/
		counting = true;

		while (numeroVidas > 0) {

			GameObject ball = balls [Random.Range (0, balls.Length)];

			int x = Random.Range (0,caidas.Length);
			// posicion de los vectores donde saldran los objetos
			Vector3 spawnPosition = new Vector3 (
				caidas[x].transform.position.x, 
				caidas[x].transform.position.y, 
				0.0f
				);

			Quaternion spawnRotation = Quaternion.identity; // no hay ninguna rotacion
			GameObject objectIncreaseSize =  Instantiate (ball, spawnPosition, spawnRotation) as GameObject;
			objectIncreaseSize.transform.localScale = Vector3.one * prefabsScale;
			yield return new WaitForSeconds (Random.Range (SpawnTime/2, SpawnTime));
			
		}

		//yield return new WaitForSeconds (2.0f);
		//gameOverText.GetComponent<GUIText>().text =  "Has perdido";
		//gameOverText.SetActive (true);
		//yield return new WaitForSeconds (2.0f);
		//restartButton.SetActive (true);

	}
}
