using UnityEngine;
using System.Collections;
using System;
using System.ComponentModel;
using System.Diagnostics;

public class CloseApplications : MonoBehaviour {

	void OnApplicationQuit() {
		try{
			CerrarProcesos("EyeTribeUIWin");
			CerrarProcesos("EyeTribe");
			CerrarProcesos("myGaze-Client");
			CerrarProcesos("vrpn_server");
			CerrarProcesos("ServidorVRPNToUnity");
		}catch{

		}
	}

	private void CerrarProcesos(string proceso){

		try{
			Process[] process = Process.GetProcessesByName(proceso);
			process[0].CloseMainWindow();
		}catch{
		}
	}
}
