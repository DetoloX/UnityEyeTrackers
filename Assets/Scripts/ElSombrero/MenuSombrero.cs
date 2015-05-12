using UnityEngine;
using System.Collections;

public class MenuSombrero : MonoBehaviour {
	public GUISkin guiSkin;
	// Use this for initialization
	public DestruyeGameController destruyeGameController;
	public GUIText textoMonedas;
	public GUIText textoPuntos;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		
		textoMonedas.text = "Monedas: \n"  + destruyeGameController.GetCoins();
		textoPuntos.text = "Puntos: \n" + destruyeGameController.Getpoints();
		/*if(showScore){
			GUI.skin = guiSkin;
			string scoreString = score.ToString();// + " " +  PlayerPrefs.GetInt("numberOfChances").ToString();
			GUILayout.BeginArea(new Rect((Screen.width / 2)-30, 55, 80, 80));
			GUILayout.BeginHorizontal();
			GUILayout.Label(scoreString, "scoreLabelHigh");
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}*/
		
		if (destruyeGameController.getIsWaiting() || destruyeGameController.getIsNextPhase() || destruyeGameController.getIsDie()){//gameOver && !firstRun) {
			GUI.skin = guiSkin;
			float aAlto =530;
			float aAncho = 700;
			// area del menu LTWH
			// left top with heigh
			
			GUILayout.BeginArea(new Rect(50, 50, 560, 480));
			GUILayout.BeginVertical("menuWinner", GUILayout.Width(560), GUILayout.Height(480));
			GUILayout.Label("Siguiente fase!!", "title");
			GUILayout.EndVertical();
			GUILayout.EndArea();
			// left, top, button, right
			GUILayout.BeginArea(new Rect(560, (Screen.height / 2) - (aAlto/2), aAncho, aAlto));
			GUILayout.BeginVertical("panelBlack", GUILayout.Width(aAncho), GUILayout.Height(aAlto));
			
			GUILayout.BeginHorizontal();
			if(PlayerPrefs.GetInt("isUltimate")==1)
				GUILayout.Label("Siguiente fase!!", "title");
			else
				GUILayout.Label("Has fallado", "title");
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			if(PlayerPrefs.GetInt("isUltimate")==1)
				GUILayout.Label("Siguiente fase!!", "title");
			else
				GUILayout.Label("Fase " + destruyeGameController.LevelNumber(), "title");
			GUILayout.EndHorizontal();
			
			GUILayout.Space(40);
			
			GUILayout.BeginHorizontal();
			
			GUILayout.BeginVertical();
			GUILayout.Label("Tus puntos", "scoreLabelNow");
			GUILayout.EndVertical();
			
			GUILayout.Space(10);
			
			GUILayout.BeginVertical();
			GUILayout.Label("Top", "scoreLabelHigh");
			
			GUILayout.EndVertical();
			
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			
			GUILayout.BeginVertical();
			GUILayout.Label("Puntos: " + destruyeGameController.Getpoints(), "scoreLabelNow");
			GUILayout.EndVertical();
			
			GUILayout.Space(10);
			
			GUILayout.BeginVertical();
			GUILayout.Label("Puntos: " + PlayerPrefs.GetInt("DestruyePoints").ToString(), "scoreLabelHigh");
			
			GUILayout.EndVertical();
			
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			
			GUILayout.BeginVertical();
			GUILayout.Label("Monedas: " + destruyeGameController.GetCoins(), "scoreLabelNow");
			
			GUILayout.EndVertical();
			
			GUILayout.Space(10);
			
			GUILayout.BeginVertical();
			GUILayout.Label("Monedas: " + PlayerPrefs.GetInt("DestruyeCoins").ToString(), "scoreLabelHigh");
			
			GUILayout.EndVertical();
			
			GUILayout.EndHorizontal();
			
			GUILayout.Space(20);
			
			GUILayout.BeginHorizontal();
			
			GUILayout.FlexibleSpace();
			
			if (GUILayout.Button("", "playAgainButton", GUILayout.Width(200), GUILayout.Height(90))) {
				//if (GUILayout.Button("NORMAL")){//, "playAgainButton", GUILayout.Width(123), GUILayout.Height(38))) {
				// Restart game is we press Play Again button.

				destruyeGameController.RestartGame(false);
			}
			
			// button ultimate
			//GUILayout.Space(20);
			GUILayout.FlexibleSpace();
			GUILayout.Space(20);
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("", "playAgainButtonUltimate", GUILayout.Width(200), GUILayout.Height(90))) {
				//if (GUILayout.Button("ULTIMATE")){//, "playUltimateButton", GUILayout.Width(123), GUILayout.Height(38))) {
				// Restart game is we press Play Again button.
				Application.LoadLevel (0);
				//destruyeGameController.RestartGame(false);
				//Application.LoadLevel (1);
			}
			
			GUILayout.FlexibleSpace();
			
			GUILayout.EndHorizontal();
			
			GUILayout.EndVertical();
			GUILayout.EndArea();
			
		}
		
		
		
		
	}
}
