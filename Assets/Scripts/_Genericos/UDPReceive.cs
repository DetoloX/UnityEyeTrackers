using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using SimpleJSON;
using System.Threading;
using System.Diagnostics;

public class UDPReceive : MonoBehaviour {
	// receiving Thread
	Thread receiveThread;
	// udpclient object
	UdpClient client;
	// public
	// public string IP = "127.0.0.1"; default local
	public int port; // define > init
	// infos
	public string lastReceivedUDPPacket="";
	public string allReceivedUDPPackets=""; // clean up this from time to time!
	// FaceAPI
	public double xPos;
	public double yPos;
	public float zPos;
	private EyeGazeTracker eyeGaze = new EyeGazeTracker ();
	private EyeTribeTracker eyeTribe = new EyeTribeTracker();
	public Tracker eyeTracker = new EyeTribeTracker();
	public float rangoOffset = 20;
	private IPHostEntry ipHostInfo;
	private IPAddress ipAddress;
	private IPEndPoint remoteEP ;
	public ErroresWarnings errores;
	private int status = 0;
	//public System.Collections.Generic.List<Tracker> eyeTrackers = new System.Collections.Generic.List<Tracker>();
	public Tracker prueba;
	byte[] bytes = new byte[1024];
	private Socket sender = new Socket(AddressFamily.InterNetwork, 
	                                   SocketType.Stream, ProtocolType.Tcp );
	// start from shell
	private static void Main()
	{
		UDPReceive receiveObj=new UDPReceive();
		receiveObj.Init();
		string text="";
		do
		{
			text = Console.ReadLine();
		}
		while(!text.Equals("exit"));
	}
	// start from unity3d
	public void Start()
	{
		Init();
	//	eyeTrackers.Add (eyeTribe);
	}
	string paquete = "";
	
	// OnGUI
	void OnGUI()
	{
			 Rect rectObj=new Rect(40,10,200,400);
		 GUIStyle style = new GUIStyle();
		 style.alignment = TextAnchor.UpperLeft;
		try{
		//	if (paquete.Length > 600) {
		//		GUI.Box (rectObj, "# UDPReceive\n127.0.0.1 " + port + " #\n"
		//		         + "shell> nc -u 127.0.0.1 : " + port + " \n"
		//		         + "\nLast Packet: \n" + paquete.Substring (0, 200) + " \n"
		//		         + paquete.Substring (200, 200) + " \n"
		//		         + paquete.Substring (200,400) + " \n"
		//		         + paquete.Substring (400) + " \n"
		//		         + "\n\nAll Messages: \n" + allReceivedUDPPackets
		//		         , style);
		//	}
		}catch{
		}
	}
	// init
	private void Init()
	{
		// Terminator point define by which the news is sent
		print("UDPSend.init()");

		// define port
		port = 11000;
	
		print("Sending to 127.0.0.1 : "+port);
		print("Test-Sending to this Port: nc -u 127.0.0.1 "+port+"");

		// ----------------------------
		// Monitor
		// ----------------------------
		// Local terminator point define (where news is received).
		// A new Thread created for the reception of incoming info.
		
		client = new UdpClient(port);
		ipHostInfo = Dns.Resolve(Dns.GetHostName());
		ipAddress = ipHostInfo.AddressList[0];
		remoteEP  = new IPEndPoint(ipAddress,11000);
		receiveThread = new Thread(
			new ThreadStart(Conectar));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}
	// se ejecuta en erroresWarnings, para volver a ejecutar todo y ver que problemas hubo
	public void ReintentarConectar(){

		receiveThread = new Thread(
			new ThreadStart(Conectar));
		receiveThread.IsBackground = true;
		receiveThread.Start();

//		errores.HayError = true;

	}

	private void Conectar(){
		errores.HayError = IsExecutingApplication("form1");

		
		if (!errores.HayError) {
			try {
				sender.Connect (remoteEP);
			} catch (Exception e) {
				Console.WriteLine ("Unexpected exception : {0}", e.ToString ());
		
				errores.HayError = true;
//				sender.Disconnect();
				receiveThread.Abort();
			}
		;
			ReceiveData ();
		} else {
		//	
			receiveThread.Abort();
		}
	}


	private void ReceiveData()
	{
		int bytesSent,bytesRec;
		bytesSent = bytesRec = 0;
		Console.WriteLine("Socket connected to {0}",
		                  sender.RemoteEndPoint.ToString());
		// Encode the data string into a byte array.
		byte[] msg = Encoding.ASCII.GetBytes("enviado desde cliente");
		// Send the data through the socket.
		bytesSent = sender.Send(msg);
		// Receive the response from the remote device.
		bytesRec = sender.Receive(bytes);
		//print(Encoding.ASCII.GetString(bytes,0,bytesRec));
		
		int i = 0;
		while(true){
			remoteEP  = new IPEndPoint(ipAddress,11000);
			bytesRec = sender.Receive(bytes);
			paquete = Encoding.ASCII.GetString(bytes,0,bytesRec);
			bytes = new byte[1024];
			bytesRec = 0;
			TraducirPaquete();
		}
		// Release the socket.
		sender.Shutdown(SocketShutdown.Both);
		sender.Close();
	}
	// receive thread
	


	private static bool IsExecutingApplication(string app)
	{
		// Proceso actual
		Process currentProcess = Process.GetCurrentProcess();
		
		// Matriz de procesos
		Process[] processes = Process.GetProcesses();
		
		// Recorremos los procesos en ejecución
		foreach (Process p in processes)
		{
			// if (p.Id != currentProcess.Id)
			// {
			try{
				if (p.ProcessName == app)
				{
					return true;
					Console.Write(p.ProcessName + "\n");
				}
			}catch{
			}


			//}
		}
		return false;
	} 

	


	
	public int GetStatus(){
		return status;
	}
	

	
	private void OnApplicationQuit() {
		// Make sure prefs are saved before quitting.
		//sender.Shutdown(SocketShutdown.Both);
		CerrarConexionUPD ();
	}

	public void OnLevelWasLoaded(){
	
	}

	public void OnDestroy(){
		CerrarConexionUPD ();
	}
	public void CerrarConexionUPD(){
		try{
			sender.Close();
			client.Close ();
		}catch{
		}

	}
	
	private void TraducirPaquete(){
		string strTemp;
		//xPos += 213;
		//yPos += 235;
		
		try{
			
			int first = paquete.IndexOf("{ \"dispositivo") ;
			int last = paquete.Substring(first).IndexOf("\" }");

			string str2;
			if (first < last){
				paquete = paquete.Substring(first, last + 3);
			}else{
				paquete = "";
			}
		//	paquete = paquete.Replace(",",".");
			JSONNode json;
			if(paquete != ""){
				json = JSONNode.Parse(paquete);
				int statusVRPN = Convert.ToInt32 (json["getStatusVRPN"]);

				if (statusVRPN == 1){
				
					status = 1;
					// encuentra en la cadena que datos esta mandando, si es del eyetribe o del my gaze
					if (paquete.IndexOf("EyeTribe") > 0){
						eyeTribe.FillWithJSon(json);
						prueba = eyeTribe;
					}else{
						eyeGaze.FillWithJSon(json);
						prueba = eyeGaze;
					}
				}else{
					status = 0;
				}
				//	print(eyeTrackers[0].PrintInfo());
			}else{

			}
				
				

		}catch (Exception e) {
			status = 0;
			Console.WriteLine("Unexpected exception : {0}", e.ToString());
		}
		
		
		
		
		
	}
	
	private bool  Between(float num, double min, double max) {
		return min <= num && num <= max;
	}
	
	private void parseString(String text)
	{
		/*String[] str = text.Split(' ');
		int index = 0;
		xPos = float.Parse(str[index++]);
		yPos = float.Parse(str[index++]);
		zPos = float.Parse(str[index++]);
		pitch = float.Parse(str[index++]);
		yaw = float.Parse(str[index++]);
		roll = float.Parse(str[index++]);*/
		//print("xpos = "+ xPos + "ypos = " + yPos);
	}
	// getLatestUDPPacket
	// cleans up the rest
	public string getLatestUDPPacket()
	{
		allReceivedUDPPackets="";
		return lastReceivedUDPPacket;
	}
	void OnDisable()
	{
		if ( receiveThread!= null)
			receiveThread.Abort();
		//client.Close();
	}
}