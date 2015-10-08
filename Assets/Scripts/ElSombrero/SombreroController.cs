using UnityEngine;
using System.Collections;

public class SombreroController : MonoBehaviour {


	public HT_GameController gameController;
	[Header("Control de sonido")]
	public AudioClip mySound;
	public AudioSource mySource;
	public float myVolume = 1.0f;
	public GameObject scriptsObjeto;
	[Header("Sprite Sin Conexion")]
	public Sprite sinConexion;
	public Sprite conConexion;
	void OnTriggerEnter2D  (Collider2D collision) {

		if (collision.gameObject.tag == "Enemy") {
			gameController.TocoBomba ();
		} else if (collision.gameObject.tag == "Friend") {
			mySource.PlayOneShot( mySound, myVolume );
			gameController.TocoPelota ();
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			gameController.TocoBomba ();
	}


	private bool huboCambio = true;
	void FixedUpdate(){
		bool hayConexion = this.GetComponent<MoveObject> ().HayConexion;
		if (hayConexion != huboCambio) {
			if (!this.GetComponent<MoveObject> ().HayConexion) {

				//	this.GetComponent<SpriteRenderer> ().color = Color.red;
				this.GetComponent<SpriteRenderer> ().sprite = sinConexion;
			} else {
				this.GetComponent<SpriteRenderer> ().sprite = conConexion;
			}
			huboCambio = hayConexion;
		}
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
