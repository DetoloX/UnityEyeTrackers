using UnityEngine;
using System.Collections;

public class DestruyeStart : MonoBehaviour {

	public DestruyeGameController gameController;
	public BotonesController botonesController;

	// Use this for initialization
	void Start () {
		
	}
	void OnMouseDown () {
		IsStart ();
	}
	
	public void IsStart(){
		gameController.IsStart (false);

	}
	// Update is called once per frame
	void Update () {
		if (botonesController.EstaActivo) {
			IsStart();
			botonesController.EstaActivo = false;
		}
		
	}
}
