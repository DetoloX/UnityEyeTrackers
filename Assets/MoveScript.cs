using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public Vector2 force = new Vector2(10, 10);
	void Start()
	{
		GetComponent<Rigidbody2D>().AddForce(force);
	}
}
