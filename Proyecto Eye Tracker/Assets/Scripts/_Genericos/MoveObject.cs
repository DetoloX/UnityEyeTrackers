using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	
	public Camera mainCamara;
	public UDPReceive uDPReceive;
	private double x = 0;
	private double y = 0 ;
	private float witdhScreen, heightScreen;
	[Header("Caso especial, solo movimiento X")]
	public bool soloX = true;
	[Header("Posicion desde abajo")]
	public float yOffset = 0.0f;


	private float posX, posY, posBX, posBY;

	private bool canControl =true;


	void Start () {

		Vector3 stageDimensions = mainCamara.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,2));
		heightScreen = stageDimensions.y;
		witdhScreen = stageDimensions.x;
		
		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3(Screen.width/2, Screen.height/2,2));
		transform.position = mainCamara.ViewportToWorldPoint(v3Pos);

	}
	void FixedUpdate () {

		if (canControl) {
			x = uDPReceive.xPos; 
			y = uDPReceive.yPos; 
			if(soloX)
				y = Screen.height - yOffset;

			y -= (768 - 597); 
			Move ();
		}
	}
	
	public void ToggleControl (bool toggle) {
		canControl = toggle;
	}
	void Move ()
	{
		Vector3 v3Pos = mainCamara.ScreenToViewportPoint(new Vector3((float)x, (float)y));

		Vector3 vector3= mainCamara.ViewportToWorldPoint(v3Pos);
		transform.position = new Vector3 (vector3.x, -vector3.y, -1);
		

	}
}
