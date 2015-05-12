using UnityEngine;
using System.Collections;

public class DestruyeGameController : MonoBehaviour {
	[Header("Controlador del menu")]
	public Menu menu;
	[Header("Puntos para cambiar de nivel")]
	public int cambioNivel = 10;
	private bool isNextPhase = false;
	private int numberLevel = 0;
	private bool isWaiting = true;
	private bool isDie = false;
	private int coins = 0;
	private int points = 0;


	public int GetCoins(){
		return coins;
	}

	public int Getpoints(){
		return points;
	}

	public int LevelNumber(){
		return numberLevel;
	}

	public bool getIsWaiting(){
		return isWaiting;
	}
	public bool getIsNextPhase(){
		return isNextPhase;
	}
	
	public void addCoin(){
		coins ++;
		menu.TextoDerArriba = "Monedas: \n" + coins;

	}

	public void addPoints(){
		points ++;
		menu.TextoIzqArriba = "Puntos: \n" + points;

	}

	private void ActualizarRecords(){
		int puntos, monedas;
		monedas = PlayerPrefs.GetInt ("DestruyeCoins");
		puntos = PlayerPrefs.GetInt("DestruyePoints");
		// actualizamos los records
		if(coins > monedas)
			PlayerPrefs.SetInt("DestruyeCoins", coins);
		if(points > puntos)
			PlayerPrefs.SetInt("DestruyePoints", points);
		
		monedas = PlayerPrefs.GetInt ("DestruyeCoins");
		puntos = PlayerPrefs.GetInt("DestruyePoints");

		menu.TxtIzqHigh = "Puntos: \n " + puntos;
		menu.TxtDerHigh = "Monedas: \n " + monedas;
		menu.TxtIzq = "Puntos: \n " + points;
		menu.TxtDer = "Monedas: \n " + coins;
		menu.Nivel = numberLevel;
		
	}

	// resetea los datos para que vuelva a iniciar el juego..
	private void ReseteaRecords(){
		coins = 0;
		points = 0;
	}

	public void IsDie(bool value){
		ActualizarRecords ();
		isDie = value;
		ReseteaRecords ();
		if(isDie){
			menu.IsDie= true;
			DeActiveSpawners ();
			EnabledBird ();
			//ActivateBirdSpawner();
		}else{ 
			QuitarMenu();
			ActivateSpawners ();
		}
	}

	public bool getIsDie(){
		return isDie;
	}
	
	public void IsStart(bool value){
		ActualizarRecords ();
		isWaiting = value;
		if(isWaiting){
			menu.IsStart= true;
			DeActiveSpawners ();
		}else{ 
			QuitarMenu();
			ActivateSpawners ();
		}
	}

	private void QuitarMenu(){
		menu.IsStart = false;
		menu.IsNextPhase = false;
		menu.IsDie = false;
	}


	public void IsNextPhase(bool value){

		isNextPhase = value;

		if(isNextPhase){
			numberLevel++;
			ActualizarRecords ();
			menu.IsNextPhase= true;
			DeActiveSpawners ();
		}else{ 
			QuitarMenu();
			ActivateSpawners ();
			oneTime = false;
		}

	}

	// Use this for initialization
	void Start () {
		ActualizarRecords ();
	}


	public bool ActivarSiguienteFase
	{
		get { return oneTime; }
		set { oneTime = value; }
	}

	// Update is called once per frame
	private bool oneTime = false;
	private int puntosAux  = -1;
	void FixedUpdate () {
		//Determina cuando es el cambio de fase, para aumentar el nivel de dificultad
		if (points > 0 && points % cambioNivel == 0 && oneTime == false && puntosAux != points) {
			oneTime = true;
			IsNextPhase(true);
			puntosAux = points;
		}
	}

	private void DeActiveSpawners(){
		GameObject go = GameObject.Find("spawner");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().CancelInvoke ();	
		go = GameObject.Find("spawnerCoinsLeft");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().CancelInvoke();
		go = GameObject.Find("spawnerCoinsRight");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().CancelInvoke();

		go = GameObject.Find("spawnerBird");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().CancelInvoke();

		EliminarTodosObjetos ();
		// elimino los ovnis que quedan por ahi

		//StartCoroutine("EnabledBird");
	
	}

	public void EliminarTodosObjetos(){
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject game in gameObjects) {
			Destroy(game);
		}
	}

	private void  EnabledBird (){
		//yield return new WaitForSeconds(2f);
		GameObject go = GameObject.Find("spawnerBird");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().enabled = true;

	}

	private void ActivateBirdSpawner(){
		GameObject go = go = GameObject.Find("spawnerBird");
		go.GetComponent<Spawner> ().enabled = false;
		go.GetComponent<Spawner> ().enabled = true;
	}

	private void ActivateSpawners(){
		GameObject go = GameObject.Find("spawner");
		go.GetComponent<Spawner> ().enabled = true;
		go = GameObject.Find("spawnerCoinsLeft");
		go.GetComponent<Spawner> ().enabled = true;
		go = GameObject.Find("spawnerCoinsRight");
		go.GetComponent<Spawner> ().enabled = true;
	}

	public void RestartGame(bool asdf){
		isWaiting = false;
		isDie = false;
		isNextPhase = false;
		ActivateSpawners ();
		menu.IsStart = true;
	}
}
