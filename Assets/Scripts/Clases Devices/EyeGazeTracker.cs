using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using SimpleJSON;



public class EyeGazeTracker : Tracker
{
	public EyeGazeTracker( ) : base() {} 
	public float Duration { get; set; }
	public float EndTime { get; set; }
	public float StartTime { get; set; }
	public EyeGaze leftEye;
	public EyeGaze rightEye;

	
	/*	var = "{ \"dispositivo\":\"EyeGaze\"," +
		"\"getStatus\":\"" + eyeGaze.getStatus().ToString() + "\"," +
			"\"getAvgX\":\"" + eyeGaze.getAvgX().ToString() + "\"," +
			"\"getAvgY\":\"" + eyeGaze.getAvgY().ToString() + "\"," +
			"\"getDuration\":\"" + eyeGaze.getDuration().ToString() + "\"," +
			"\"getEndTime\":\"" + eyeGaze.getEndTime().ToString() + "\"," +
			"\"getStartTime\":\"" + eyeGaze.getStartTime().ToString() + "\"," +
			
			"\"getTimestamp\":\"" + eyeGaze.getTimestamp().ToString() + "\"," +
			
			"\"getEyeLeftDiam\":\"" + eyeGaze.getEyeLeftDiam().ToString() + "\"," +
			"\"getEyeLeftPGazeX\":\"" + eyeGaze.getEyeLeftPGazeX().ToString() + "\"," +
			"\"getEyeLeftPGazeY\":\"" + eyeGaze.getEyeLeftPGazeY().ToString() + "\"," +
			"\"getEyeLeftPositionX\":\"" + eyeGaze.getEyeLeftPositionX().ToString() + "\"," +
			"\"getEyeLeftPositionY\":\"" + eyeGaze.getEyeLeftPositionY().ToString() + "\"," +
			"\"getEyeLeftPositionZ\":\"" + eyeGaze.getEyeLeftPositionZ().ToString() + "\"," +
			
			"\"getEyeRightDiam\":\"" + eyeGaze.getEyeRightDiam().ToString() + "\"," +
			"\"getEyeRightPGazeX\":\"" + eyeGaze.getEyeRightPGazeX().ToString() + "\"," +
			"\"getEyeRightPGazeY\":\"" + eyeGaze.getEyeRightPGazeY().ToString() + "\"," +
			"\"getEyeRightPositionX\":\"" + eyeGaze.getEyeRightPositionX().ToString() + "\"," +
			"\"getEyeRightPositionY\":\"" + eyeGaze.getEyeRightPositionY().ToString() + "\"," +
			"\"getEyeRightPositionZ\":\"" + eyeGaze.getEyeRightPositionZ().ToString() + "\" }";*/
	
	public override void  FillWithJSon(JSONNode json) 
	{

		leftEye = new EyeGaze();
		rightEye  = new EyeGaze();

		Status = float.Parse(json["getStatus"]);
		String aux = "";

		aux = json ["getAvgX"];
		AvgX = float.Parse(aux.Replace(",","."));
		aux = json ["getAvgY"];
		AvgY = float.Parse(aux.Replace(",","."));
		aux = json ["getTimeStamp"];
		TimeStamp = float.Parse(aux.Replace(",","."));


		Duration = float.Parse(json["getDuration"]);
		EndTime = float.Parse(json["getEndTime"]);
		StartTime = float.Parse(json["getStartTime"]);

		leftEye.AvgX = (json["getEyeLeftAvgX"]);
		leftEye.AvgY = (json["getEyeLeftAvgY"]);
		leftEye.Diam =  (json["getEyeLeftDiam"]);
		leftEye.PositionX =  (json["getEyeLeftPositionX"]);
		leftEye.PositionY =  (json["getEyeLeftPositionY"]);
		leftEye.PositionZ =  (json["getEyeLeftPositionZ"]);

		rightEye.AvgX =  (json["getEyeRightAvgX"]);
		rightEye.AvgY =  (json["getEyeRightAvgY"]);
		rightEye.Diam =  (json["getEyeRightDiam"]);
		rightEye.PositionX =  (json["getEyeRightPositionX"]);
		rightEye.PositionY =  (json["getEyeRightPositionY"]);
		rightEye.PositionZ =  (json["getEyeRightPositionZ"]);	
				
	}


	public override string  PrintInfo()  //override the abstract show method
	{
		System.Console.WriteLine("IsFixation : " + StartTime);
		System.Console.WriteLine("RawX : " + Duration);
		System.Console.WriteLine("RawX : " + EndTime);
		System.Console.WriteLine("AvgX : " + AvgX);
		System.Console.WriteLine("AvgY : " + AvgY);
		System.Console.WriteLine("TimeStamp : " + TimeStamp);
		System.Console.WriteLine("Status : " + Status);
		leftEye.PrintInfo ();
		rightEye.PrintInfo ();
		return StartTime.ToString();
	}

	public override string  GetStatusString()  //override the abstract show method
	{
		switch (Convert.ToInt32(Status) )
		{
		
		case 1:
			return "Tracker NO conectado.";
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




