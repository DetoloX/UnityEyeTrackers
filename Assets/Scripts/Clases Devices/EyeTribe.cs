using UnityEngine;
using System.Collections;

public class EyeTribe  : Eye {

	public EyeTribe( ) : base() {} 

	public string RawX { get; set; }
	public string RawY { get; set; }
	public string PCenterX { get; set; }
	public string PCenterY { get; set; }
	public string PSize { get; set; }
	
	public override void  PrintInfo()  //override the abstract show method
	{
		System.Console.WriteLine("RawX : " + RawX);
		System.Console.WriteLine("RawX : " + RawY);
		System.Console.WriteLine("asdf : " + AvgX);
		System.Console.WriteLine("asdf : " + AvgY);
		System.Console.WriteLine("RawX : " + PCenterX);
		System.Console.WriteLine("RawX : " + PCenterY);
		System.Console.WriteLine("asdf : " + PSize);
	}
}
