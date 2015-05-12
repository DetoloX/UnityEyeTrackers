using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 force = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>

	private Vector2 movement;


	void Start()
	{
		//rigidbody2D.AddTorque(10f);
		GetComponent<Rigidbody2D>().AddForce(force);

	}

	void Update()
	{
		// 2 - Movement
	/*	movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		Debug.Log("collisionao  "  + direction.x + " "  + direction.y);*/
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		//rigidbody2D.velocity = movement;

		//rigidbody2D.AddForce(new Vector2(0f,6f));

		//rigidbody2D.velocity =movement; // new Vector2(rigidbody2D.velocity.x,0); 
		//rigidbody2D.AddForce(new Vector2(0f,10f));
	}

	void OnCollisionEnter2D(Collision2D Collider2d){
	/*	float x, y;
		if(Collider2d.transform.name == "powerUp"){
			//do{
				//x  =  Random.Range(-2f,2f);
				//y  =  Random.Range(-2f,2f);
			//direction = new Vector2(x,y);
			//}while(x == 0 || y == 0);

			//direction = new Vector2(-direction.x ,-direction.y);

		}
		//Debug.Log("collisionao  "  + direction.x + " "  + direction.y);*/
	}

}
