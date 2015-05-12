using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

	
	public GameObject explosion;

	[Header("Efecto cuando pasa por un collider")]
	public ParticleSystem[] effects;
	public GameObject scriptsObjeto;

	void Start () {
		PararEfectos ();
	}

	public void PararEfectos(){
		foreach (var effect in effects) {
			
			effect.Stop ();
			
		}

	}

	public void Deshabilitarlo(){
		scriptsObjeto.GetComponent<SpriteRenderer> ().enabled = false;
		scriptsObjeto.GetComponent<Collider2D> ().enabled = false;
		scriptsObjeto.GetComponent<MoveObject> ().enabled = false;
		PararEfectos ();
	}

	public void Habilitarlo(){
		scriptsObjeto.GetComponent<SpriteRenderer> ().enabled = true;
		scriptsObjeto.GetComponent<Collider2D> ().enabled = true;
		scriptsObjeto.GetComponent<MoveObject> ().enabled = true;
		PararEfectos ();
	}

	void OnTriggerEnter2D (Collider2D collision) {
	
			//Instantiate (explosion, transform.position, transform.rotation);
			foreach (var effect in effects) {
				effect.Play();
				effect.loop = true;

				//effect.transform.parent = null;
				//effect.Stop ();
				//Destroy (effect.gameObject, 1.0f);
			}
		//	Destroy (gameObject);
		
	}

	void OnTriggerExit2D (Collider2D collision) {
		
		//Instantiate (explosion, transform.position, transform.rotation);
		foreach (var effect in effects) {
			effect.Stop();
			effect.loop = true;
		}

	}

}
