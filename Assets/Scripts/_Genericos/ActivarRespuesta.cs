using UnityEngine;
using System.Collections;

public class ActivarRespuesta : MonoBehaviour {

	[Header("Controlador Menu SALIR")]
	public RecolocarPosicionesSalir recolocar;
	[Header("Controlador Boton")]
	public BotonesController botonesController;
	[Header("Para que sean visibles")]
	public bool paraActivarVisibles = true;
	// Use this for initialization


	void Update () {
		try{
			
			if (botonesController.EstaActivo) {
				if (paraActivarVisibles){
					// MUESTRA LOS BOTONES ACEPTAR CANCELAR
					recolocar.ActivarRepuesta(true);
				}else{
					// OCULTA LOS BOTONES ACEPTAR CANCELAR Y MUESTRA EL SALIR
					recolocar.ActivarRepuesta(false);
				}

				botonesController.EstaActivo = false;
			}
		}catch{
		}
		
	}
}
