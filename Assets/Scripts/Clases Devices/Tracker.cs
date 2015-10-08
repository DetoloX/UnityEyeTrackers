using UnityEngine;
using System.Collections;
using SimpleJSON;
public abstract  class Tracker {

	public double AvgX { get; set; }
	public double AvgY { get; set; }
	public double Status { get; set; }

	public float TimeStamp{ get; set;}

	public abstract string PrintInfo();
	public abstract void FillWithJSon(JSONNode x);
	public abstract string GetStatusString();
	public abstract bool Comparar(Tracker t);
}
