using UnityEngine;
using System.Collections;

public class BotonesController : MonoBehaviour {
	private bool isShaking = true;
	private Vector3 vector;


	[Header("Movimiento horizontal")]
	public float movimiento = 1f;
	[Header("Segundos de movimiento")]
	public float seconds = 3.0f;
	

	private int signo = -1;

	void Start () {
		vector = this.transform.position;
	}


	void OnTriggerEnter2D(Collider2D collision){
		vector = this.transform.position;
		StartCoroutine (MoverObjeto());
	}

	void OnTriggerExit2D(Collider2D collision){
		StopAllCoroutines ();
	
	}

	void OnMouseEnter () {
		vector = this.transform.position;
		StartCoroutine (MoverObjeto());
	}

	void OnMouseExit () {
		StopAllCoroutines ();
	
	}

	public bool EstaActivo
	{
		get { return estaActivo; }
		set { estaActivo = value; }
	}

	private bool estaActivo = false;
	private IEnumerator  MoverObjeto(){
		estaActivo = false;
		for (float timer = 0; timer <= seconds; timer += Time.deltaTime)
		{
			signo = signo * -1;
			vector.x += movimiento * signo;
			transform.position = vector;
			yield return 0;
		}
		estaActivo = true;

	}
	
}

