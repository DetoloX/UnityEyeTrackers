using UnityEngine;
using System.Collections;

public class NavegacionController : MonoBehaviour {

	//public AudioSource audio;
	[Header("Controlado del movimiento boton")]
	public BotonesController botonesController;
	[Header("Control de navegacion")]
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
		// guardar preferencia de navegacion por defecto NO ACTIVADA = 0
		// activada = 1
		if (PlayerPrefs.GetInt ("Navegacion") == 0){
			GetComponent<SpriteRenderer> ().sprite = spriteOFF;
			esON = false;
		}else {
			GetComponent<SpriteRenderer> ().sprite = spriteON;
			esON = true;
		}
	}
	
	void Update () {
		
		try{
			
			if (botonesController.EstaActivo) {
				CambiaNavegacion();
				botonesController.EstaActivo = false;
			}
		}catch{
		}
		
	}
	
	void Awake() {
		
	}
	
	public void CambiaNavegacion(){
		esON = !esON;
		mySource.PlayOneShot( mySound, myVolume );
		if (esON) {
			GetComponent<SpriteRenderer> ().sprite = spriteON;
			PlayerPrefs.SetInt("Navegacion", 1) ;
		} else {
			GetComponent<SpriteRenderer> ().sprite = spriteOFF;
			PlayerPrefs.SetInt("Navegacion", 0) ;
		}
	}
}
