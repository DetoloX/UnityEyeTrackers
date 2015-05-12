using UnityEngine;
using System.Collections;

public class ForceWalls : MonoBehaviour {

	public Vector2 force = new Vector2(0, 10);

	void OnCollisionEnter2D(Collision2D collider2d){
		if(collider2d.transform.tag == "Circle" || collider2d.transform.tag == "Enemy" || collider2d.transform.tag == "Friend"){
			collider2d.rigidbody.AddForce(force);
		}
	}


	void OnTriggerEnter2D (Collider2D other) {
		//GameObject objeto = new GameObject ();
		
		if(other.tag == "Enemy" || other.tag == "Circle" || other.tag == "Friend"){
			other.GetComponent<Rigidbody2D>().AddForce(force);
		
		}
	
		
	}


}
