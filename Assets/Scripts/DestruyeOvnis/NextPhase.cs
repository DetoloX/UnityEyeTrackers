using UnityEngine;
using System.Collections;

public class NextPhase : MonoBehaviour {

	public DestruyeGameController gameController;
	public BotonesController botonesController;
	void Start () {
		
	}
	void OnMouseDown () {
		IsNextPhase ();
	}


	void Update () {
		if (botonesController.EstaActivo) {
			IsNextPhase();
			botonesController.EstaActivo = false;
		}
		
	}
	public void IsNextPhase(){
			gameController.IsNextPhase (false);
		
	}

}
