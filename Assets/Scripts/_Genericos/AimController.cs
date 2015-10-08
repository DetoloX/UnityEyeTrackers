using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

	
	public GameObject explosion;

	[Header("Efecto cuando pasa por un collider")]
	public ParticleSystem[] effects;

	public GameObject scriptsObjeto;
	[Header("Sprite SIN Conexion")]
	public Sprite sinConexion;
	[Header("Sprite CON Conexion")]
	public Sprite conConexion;
	void Start () {
		PararEfectos ();
	}

	private bool huboCambio = true;
	void FixedUpdate(){

		// comprobamos que el estado haya cambiado para solamente
		// cambiar el sprite cada vez que haya un cambio.. no constantemente en cada ciclo
		bool hayConexion = this.GetComponent<MoveObject> ().HayConexion;
		if (hayConexion != huboCambio) {
			if (!this.GetComponent<MoveObject> ().HayConexion) {
				this.GetComponent<SpriteRenderer> ().sprite = sinConexion;
			} else {
				this.GetComponent<SpriteRenderer> ().sprite = conConexion;
			}
			huboCambio = hayConexion;
		}
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
			foreach (var effect in effects) {
				effect.Play();
				effect.loop = true;
			}
	}

	void OnTriggerExit2D (Collider2D collision) {
		foreach (var effect in effects) {
			effect.Stop();
			effect.loop = true;
		}
	}

}
