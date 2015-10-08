using UnityEngine;
using System.Collections;

public class ItemsController : MonoBehaviour {
	[Header("Controlador del juego")]
	public HT_GameController gameController;
	[Header("Control de sonido")]
	public AudioClip mySound;
	public AudioSource mySource;
	public float myVolume = 0.5f;
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseOver(){

		if (gameObject.tag == "Enemy") {
			gameController.TocoBomba ();
			Destroy (gameObject);
		} else if (gameObject.tag == "Friend") {
			mySource.PlayOneShot( mySound, myVolume );
			gameController.TocoPelota ();
			Destroy (gameObject);
		}

	}
}
