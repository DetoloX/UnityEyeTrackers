using UnityEngine;
using System.Collections;

public class Sonido : MonoBehaviour {
	//public AudioSource audio;
	[Header("Controlado de los botones")]
	public BotonesController botonesController;
	[Header("Control de sonido")]
	public Sprite spriteOFF;
	public Sprite spriteON;
	public bool esON = true;
	// Use this for initialization
	private GameObject audio;

	[Header("Control efecto sonido")]
	public AudioClip mySound;
	public AudioSource mySource;
	public float myVolume = 1.0f;

	void OnMouseDown  () {
	//	CambiaMusica ();
	}

	void Start(){
		audio = GameObject.Find("Musica");
		if (audio.GetComponent<MusicaSingleton> ().IsPlaying ()) {
			GetComponent<SpriteRenderer> ().sprite = spriteON;
			esON = true;
		} else {
			GetComponent<SpriteRenderer> ().sprite = spriteOFF;
			esON = false;
		}
	}
	
	void Update () {

		try{
			
			if (botonesController.EstaActivo) {
				CambiaMusica();
				botonesController.EstaActivo = false;
			}
		}catch{
		}
		
	}

	void Awake() {

	}

	public void CambiaMusica(){
		esON = !esON;
		if (esON) {
			mySource.PlayOneShot( mySound, myVolume );
			GetComponent<SpriteRenderer> ().sprite = spriteON;
			audio.GetComponent<MusicaSingleton>().Play();

		} else {
			mySource.PlayOneShot( mySound, myVolume );
			GetComponent<SpriteRenderer> ().sprite = spriteOFF;
			audio.GetComponent<MusicaSingleton>().Stop();

		}
	
	}



}
