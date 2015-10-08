using UnityEngine;
using System.Collections;

public class EyeGaze : Eye {
	
	public EyeGaze( ) : base() {} 

	public string Diam { get; set; }
	public string PositionX { get; set; }
	public string PositionY { get; set; }
	public string PositionZ { get; set; }


	public override void  PrintInfo()  //override the abstract show method
	{
		System.Console.WriteLine("RawX : " + Diam);
		System.Console.WriteLine("asdf : " + AvgX);
		System.Console.WriteLine("asdf : " + AvgY);
		System.Console.WriteLine("RawX : " + PositionX);
		System.Console.WriteLine("RawX : " + PositionY);
		System.Console.WriteLine("asdf : " + PositionZ);
	}
}
