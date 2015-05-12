using UnityEngine;
using System.Collections;

public class PositionBox : MonoBehaviour {

	public Transform izquierda;
	public Transform derecha;
	public Transform arriba;
	public Transform abajo;
	public Camera mainCamara;
	private bool firstTime = true;
	// Use this for initialization
	void FixedUpdate () {

//		Vector3 myWorld = Camera.main.ScreenToWorldPoint(myScreen);
		
		// VECTOR3 (X;Y;Z)
		if (firstTime)
		{
			Vector3 stageDimensions = mainCamara.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,0));
			float height = stageDimensions.y;
			float width = stageDimensions.x;

			
			//		float height = izquierda.GetComponent(MeshFilter).mesh.bounds.extents.x;
			MoverCajas (izquierda, 0, 0 );
			
			MoverCajas (abajo, 0, 0);
			MoverCajas (derecha, width, 0);
			MoverCajas (arriba, 0, height);
			firstTime = !firstTime;
		}


	}

	private void MoverCajas (Transform trans, float x, float y){
		Vector3 v3Pos = new Vector3(x,y, 0);
		trans.position = mainCamara.ViewportToWorldPoint(v3Pos);


		//Vector2 vector = trans.transform.position;
		//vector.x = x;
		//vector.y = y;
		//trans.transform.position = vector;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
