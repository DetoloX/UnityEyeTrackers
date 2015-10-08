using UnityEngine;
using System.Collections;
using System;
using System.ComponentModel;
using System.Diagnostics;
public class Salir : MonoBehaviour {

	public BotonesController botonesController;

	void OnMouseDown  () {
		SalirFunction ();
	}
	
	void Update () {
		try{
			if (botonesController.EstaActivo) {
				SalirFunction ();
				botonesController.EstaActivo = false;
			}
		}catch{
		}	
	}



	public void SalirFunction(){
		try{

			CerrarProcesos("EyeTribeUIWin");
			CerrarProcesos("EyeTribe");
			CerrarProcesos("myGaze-Client");
			CerrarProcesos("vrpn_server");
			CerrarProcesos("ServidorVRPNToUnity");
			Application.Quit();
		}catch{
			
		}
	}
	
	private void CerrarProcesos(string proceso){
		Process[] processes = Process.GetProcesses();
		try{
		/*	foreach (Process p in processes)
			{
				UnityEngine.Debug.Log(p.ProcessName);
			}*/
			Process[] process = Process.GetProcessesByName(proceso);
			process[0].CloseMainWindow();
		}catch{

		}
	}
}
