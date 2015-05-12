using UnityEngine;
using System.Collections;

public class SombreroNextPhase : MonoBehaviour {

	public HT_GameController gameController;
	public BotonesController botonesController;
	void Start () {
		
	}
	//void OnMouseOver () {
	//	IsNextPhase ();
	//}
	void OnMouseDown  () {
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
