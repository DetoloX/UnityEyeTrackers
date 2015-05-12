using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
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
	public float pitch;
	public float yaw;
	public float roll;

	public float rangoOffset = 20;

	// start from shell
	private static void Main()
	{
		UDPReceive receiveObj=new UDPReceive();
		receiveObj.init();
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
		init();
	}
	string paquete = "";

	// OnGUI
	 void OnGUI()
	 {
	/*	 Rect rectObj=new Rect(40,10,200,400);
		 GUIStyle style = new GUIStyle();
		 style.alignment = TextAnchor.UpperLeft;
		
		 GUI.Box(rectObj,"# UDPReceive\n127.0.0.1 "+port+" #\n"
		 + "shell> nc -u 127.0.0.1 : "+port+" \n"
		        + "\nLast Packet: \n"+ paquete
		 + "\n\nAll Messages: \n"+allReceivedUDPPackets
		 ,style);*/
	 }
	// init
	private void init()
	{
		//xPos = 0;
		//yPos = 0;
		//zPos = 0;
		pitch = 0;// rotation around y
		yaw = 0; // rotation around z
		roll = 0;// rotation around x
		// Terminator point define by which the news is sent
		print("UDPSend.init()");
		// define port
		port = 11000;
		// status
		print("Sending to 127.0.0.1 : "+port);
		print("Test-Sending to this Port: nc -u 127.0.0.1 "+port+"");
		// ----------------------------
		// Monitor
		// ----------------------------
		// Local terminator point define (where news is received).
		// A new Thread created for the reception of incoming info.
		receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}
	// receive thread

	byte[] bytes = new byte[1024];

	private Socket sender = new Socket(AddressFamily.InterNetwork, 
	                           SocketType.Stream, ProtocolType.Tcp );

	private void ReceiveData()
	{
		client = new UdpClient(port);
		//print("ReceiveData function ");
		IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
		IPAddress ipAddress = ipHostInfo.AddressList[0];
		IPEndPoint remoteEP  = new IPEndPoint(ipAddress,11000);

		try {
			sender.Connect(remoteEP);

			Console.WriteLine("Socket connected to {0}",
			                  sender.RemoteEndPoint.ToString());
			
			// Encode the data string into a byte array.
			byte[] msg = Encoding.ASCII.GetBytes("enviado desde cliente");
			
			// Send the data through the socket.
			int bytesSent = sender.Send(msg);
			
			// Receive the response from the remote device.
			int bytesRec = sender.Receive(bytes);
			print(Encoding.ASCII.GetString(bytes,0,bytesRec));

			int i = 0;
			while(true){

				remoteEP  = new IPEndPoint(ipAddress,11000);
				bytesRec = sender.Receive(bytes);

				if(i == 0){
					print(Encoding.ASCII.GetString(bytes,0,bytesRec));
				}
				i =2;
				paquete = Encoding.ASCII.GetString(bytes,0,bytesRec);
				TraducirPaquete();
			}

			// Release the socket.
			sender.Shutdown(SocketShutdown.Both);
			sender.Close();
			
		} catch (ArgumentNullException ane) {
			Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
		} catch (SocketException se) {
			Console.WriteLine("SocketException : {0}",se.ToString());
		} catch (Exception e) {
			Console.WriteLine("Unexpected exception : {0}", e.ToString());
		}
	
	}

	private void OnApplicationQuit() {
		// Make sure prefs are saved before quitting.
		sender.Shutdown(SocketShutdown.Both);
		sender.Close();
	}

	private void TraducirPaquete(){
		string strTemp;
		//xPos += 213;
		//yPos += 235;
		
		try{

			string[] strTempFull = paquete.Split('F');
			for (int i =0; i< strTempFull.GetLength(0); i++) {
				
				if (strTempFull [i].IndexOf ("X-") == 0) {
					//	if (strTempFull [i].IndexOf ("-") > strTempFull [i].IndexOf ("X-")+1 ) {
					string[] strTempTodo = strTempFull [i].Split ('-');
					if (strTempTodo.Length >= 2 && strTempTodo [0] == "X") {
						// el paquete esta correctamente formado
						//string prueba = strTempTodo [1].Substring(0,6).Replace(",",".");
						
						//float xaa = Convert.ToSingle (prueba);
						
						// SI LA POSICION ESTA DENTRO DE UN RANGO, PARA QUE NO SE MUEVA TANTO..
						
						if (!Between(Convert.ToSingle (strTempTodo [1].Replace(",",".")), xPos- rangoOffset, xPos + rangoOffset)){
							xPos = Convert.ToSingle (strTempTodo [1].Replace(",","."));
						}
						
						if (!Between(Convert.ToSingle (strTempTodo [2].Replace(",",".")), yPos- rangoOffset, yPos + rangoOffset)){
							yPos = Convert.ToSingle (strTempTodo [2].Replace(",","."));
						}
						
						break;
					}
					//	}
				}
			}

		}catch (Exception e) {
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
		client.Close();
	}
}