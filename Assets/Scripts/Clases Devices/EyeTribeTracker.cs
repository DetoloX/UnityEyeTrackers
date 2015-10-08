using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using SimpleJSON;



public class EyeTribeTracker : Tracker
{
	public EyeTribeTracker( ) : base() {} 
	public float RawX { get; set; }
	public float RawY { get; set; }
	public float IsFixation { get; set; }
	public EyeTribe leftEye = new EyeTribe();
	public EyeTribe rightEye  = new EyeTribe();




	/*var = "{ \"dispositivo\":\"EyeTribe\"," +
		"\"getStatus\":\"" + eyeTribe.getStatus().ToString() + "\"," +
			"\"getAvgX\":\"" + eyeTribe.getAvgX().ToString() + "\"," +
			"\"getAvgY\":\"" + eyeTribe.getAvgY().ToString() + "\"," +
			"\"getRawX\":\"" + eyeTribe.getRawX().ToString() + "\"," +
			"\"getRawY\":\"" + eyeTribe.getRawY().ToString() + "\"," +
			"\"getTime\":\"" + eyeTribe.getTime().ToString() + "\"," +
			"\"getIsFixation\":\"" + eyeTribe.getIsFixation().ToString() + "\"," +
			
			"\"getEyeLeftAvgX\":\"" + eyeTribe.getEyeLeftAvgX().ToString() + "\"," +
			"\"getEyeLeftAvgY\":\"" + eyeTribe.getEyeLeftAvgY().ToString() + "\"," +
			"\"getEyeLeftPCenterX\":\"" + eyeTribe.getEyeLeftPCenterX().ToString() + "\"," +
			"\"getEyeLeftPCenterY\":\"" + eyeTribe.getEyeLeftPCenterY().ToString() + "\"," +
			"\"getEyeLeftPSize\":\"" + eyeTribe.getEyeLeftPSize().ToString() + "\"," +
			"\"getEyeLeftRawX\":\"" + eyeTribe.getEyeLeftRawX().ToString() + "\"," +
			"\"getEyeLeftRawY\":\"" + eyeTribe.getEyeLeftRawY().ToString() + "\"," +
			
			"\"getEyeRightAvgX\":\"" + eyeTribe.getEyeRightAvgX().ToString() + "\"," +
			"\"getEyeRightAvgY\":\"" + eyeTribe.getEyeRightAvgY().ToString() + "\"," +
			"\"getEyeRightPCenterX\":\"" + eyeTribe.getEyeRightPCenterX().ToString() + "\"," +
			"\"getEyeRightPCenterY\":\"" + eyeTribe.getEyeRightPCenterY().ToString() + "\"," +
			"\"getEyeRightPSize\":\"" + eyeTribe.getEyeRightPSize().ToString() + "\"," +
			"\"getEyeRightRawX\":\"" + eyeTribe.getEyeRightRawX().ToString() + "\"," +
			"\"getEyeRightAvgX\":\"" + eyeTribe.getEyeRightAvgX().ToString() + "\" }"; */

	public override void  FillWithJSon(JSONNode json) 
	{
		leftEye = new EyeTribe();
		rightEye  = new EyeTribe();
		Status = float.Parse(json["getStatus"]);
		AvgX = float.Parse(json["getAvgX"]);
		AvgY = float.Parse(json["getAvgY"]);
		RawX = float.Parse(json["getRawX"]);
		RawY = float.Parse(json["getRawY"]);
		TimeStamp = float.Parse(json["getTime"]);
		IsFixation = float.Parse(json["getIsFixation"]);

		leftEye.AvgX = (json["getEyeLeftAvgX"]);
		leftEye.AvgY =  (json["getEyeLeftAvgY"]);
		leftEye.PCenterX =  (json["getEyeLeftPCenterX"]);
		leftEye.PCenterY =  (json["getEyeLeftPCenterY"]);
		leftEye.PSize =  (json["getEyeLeftPSize"]);
		leftEye.RawX =  (json["getEyeLeftRawX"]);
		leftEye.RawY =  (json["getEyeLeftRawY"]);

		rightEye.AvgX =  (json["getEyeRightAvgX"]);
		rightEye.AvgY =  (json["getEyeRightAvgY"]);
		rightEye.PCenterX =  (json["getEyeRightPCenterX"]);
		rightEye.PCenterY =  (json["getEyeRightPCenterY"]);
		rightEye.PSize =  (json["getEyeRightPSize"]);
		rightEye.RawX =  (json["getEyeRightRawX"]);
		rightEye.RawY =  (json["getEyeRightRawY"]);
		
	}
	

	public override string  PrintInfo()  //override the abstract show method
	{
		System.Console.WriteLine("RawX : " + RawX);
		System.Console.WriteLine("RawX : " + RawY);
		System.Console.WriteLine("AvgX : " + AvgX);
		System.Console.WriteLine("AvgY : " + AvgY);
		System.Console.WriteLine("TimeStamp : " + TimeStamp);
		System.Console.WriteLine("Status : " + Status);
		System.Console.WriteLine("IsFixation : " + IsFixation);

		return "RawX : " + RawX + " " +
			"RawX : " + RawY + " " +
			"AvgX : " + AvgX + " " +
			"TimeStamp : " + TimeStamp + " " +
			"Status : " + Status + " " +
			"IsFixation : " + IsFixation;

		leftEye.PrintInfo ();
		rightEye.PrintInfo ();
	}
	/*enum
{
	TRACKER_CONNECTED          = 0,
	TRACKER_NOT_CONNECTED      = 1,
	TRACKER_CONNECTED_BADFW    = 2,
	TRACKER_CONNECTED_NOUSB3   = 3,
	TRACKER_CONNECTED_NOSTREAM = 4
};*/

	public override string  GetStatusString()  //override the abstract show method
	{
		// los primero 10001 y 10002 son genericos de los dispositivos, los gestiona la clase UDPReceived
		switch (Convert.ToInt32(Status) )
		{
		
		case 1:
			return "Tracker NO conectado.";
			break;
		case 2:
			return "Tracker conectado BAD FW.";
			break;
		case 3:
			return "Tracker conectado NO USB3.";
			break;
		case 4:
			return "Tracker conectado NO STREAM.";
			break;
		}

		return "";
	}

	public override bool  Comparar(Tracker t ) {
		if (AvgX == t.AvgX && AvgY == t.AvgY) {
			return true;
		} else {
			return false;	
		}
		
	}

}

