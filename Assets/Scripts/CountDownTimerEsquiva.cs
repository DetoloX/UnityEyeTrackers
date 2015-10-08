using UnityEngine;
using System.Collections;

public class CountDownTimerEsquiva : MonoBehaviour {
	[Header("Tiempo temporizador")]
	public float timer = 60.0f;
	private bool terminado = false;
	[Header("Controlador del juego")]
	public HT_GameController gameController;
	[Header("Estilos")]
	public GUISkin guiSkin;
	// Use this for initialization
	private float timerAux = 60.0f;
	public bool isActivado = true;
	void Start () {
		timerAux = timer;
	}
	
	public void ReiniciarCountDown(){
		timer = timerAux;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isActivado) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				isActivado = false;
				gameController.IsNextPhase (true);
				timer = 0;
				
			}
		} 
		//	if (gameController.getIsNextPhase)
		//		timer = timerAux;
		
	}
	
	void OnGUI(){
		if (timer >= 0 && isActivado) {
			GUI.skin = guiSkin;
			GUI.Box (new Rect (Screen.width / 2, 10, 30, 30), "" + timer.ToString ("0"), "temporizador");
		}
	}
	
}