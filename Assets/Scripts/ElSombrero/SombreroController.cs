using UnityEngine;
using System.Collections;

public class SombreroController : MonoBehaviour {


	public HT_GameController gameController;
	public GameObject scriptsObjeto;

	void OnTriggerEnter2D  (Collider2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			gameController.TocoBomba ();
		} else if (collision.gameObject.tag == "Friend") {
			gameController.TocoPelota ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			gameController.TocoBomba ();
	}




	public void Deshabilitarlo(){
		scriptsObjeto.GetComponent<Collider2D> ().enabled = false;
		scriptsObjeto.GetComponent<MoveObject> ().enabled = false;
		
	}
	
	public void Habilitarlo(){
		scriptsObjeto.GetComponent<Collider2D> ().enabled = true;
		scriptsObjeto.GetComponent<MoveObject> ().enabled = true;
	}


}
