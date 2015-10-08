using UnityEngine;
using System.Collections;

public class GoToLevelClick : MonoBehaviour {

	public BotonesController botonesController;
	public int level =0;
	// Use this for initialization

	void OnMouseDown  () {
		CambiaNivel ();
	}
	
	void Update () {
		try{

			if (botonesController.EstaActivo) {
				CambiaNivel();
				botonesController.EstaActivo = false;
			}
		}catch{
		}
		
	}
	public void CambiaNivel(){
		try{
			Application.LoadLevel (level);
		}catch{
		}

	}

}
