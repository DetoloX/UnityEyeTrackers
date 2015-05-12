using UnityEngine;
using System.Collections;

public class SombreroTogglePosicionX : MonoBehaviour {
	[Header("Determinar si el sombrero es fijo o no")]
	public MoveObject sombrero;

	public HT_GameController gameController;
	public BotonesController botonesController;
	[Header("Imagen determina si esta on o off")]
	public Sprite spriteOn;
	public Sprite spriteOff;
	// Use this for initialization
	void Start () {
		
	}
	void OnMouseDown  () {
		IsStart ();
	}
	
	public void IsStart(){
		sombrero.soloX = !sombrero.soloX;
		if (sombrero.soloX) {
			transform.GetComponent<SpriteRenderer>().sprite = spriteOn;
		} else {
			transform.GetComponent<SpriteRenderer>().sprite = spriteOff;
		}

	}
	// Update is called once per frame
	void Update () {
		if (botonesController.EstaActivo) {
			IsStart();
			botonesController.EstaActivo = false;
		}
		
	}
}
