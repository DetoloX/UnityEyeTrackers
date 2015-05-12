using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {


	public Vector2 gravity = new Vector2 (0, 0);

	void Start ()
	{
		Physics2D.gravity = gravity;
	}


	

}
