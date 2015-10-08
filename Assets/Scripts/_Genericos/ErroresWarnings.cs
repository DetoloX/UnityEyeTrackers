using UnityEngine;
using System.Collections;
using System;
public class ErroresWarnings : MonoBehaviour {

	public GUISkin guiSkin;
	public UDPReceive updReceive;
	public bool HayError { get; set; }
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		// primero comprobamos errores de conexion del servidor.. luego de los dispositivos
		if(HayError)
			if (updReceive.GetStatus() > 0) {
				Time.timeScale = 0;
				GUI.skin = guiSkin;
				float aAlto = Screen.height;
				float aAncho = Screen.width;
				GUILayout.BeginArea (new Rect (100, 100, (aAncho - 200), aAlto - 200));
				GUILayout.BeginVertical ("panelBlack", GUILayout.Width ((aAncho - 200)), GUILayout.Height ((aAlto - 200)));
//				GUILayout.Label (updReceive.GetStatusString ());
				GUILayout.EndVertical ();
				GUILayout.EndArea ();
			} else {

				if (updReceive.eyeTracker.Status > 0) {

					Time.timeScale = 0;
					GUI.skin = guiSkin;
					float aAlto = Screen.height;
					float aAncho = Screen.width;
					GUILayout.BeginArea (new Rect (100, 100, (aAncho - 200), aAlto - 200));
					GUILayout.BeginVertical ("panelBlack", GUILayout.Width ((aAncho - 200)), GUILayout.Height ((aAlto - 200)));
					GUILayout.Label (updReceive.eyeTracker.GetStatusString ());
					GUILayout.EndVertical ();
					GUILayout.EndArea ();
				} else {
					Time.timeScale = 1;
				}
			}



	}


}
