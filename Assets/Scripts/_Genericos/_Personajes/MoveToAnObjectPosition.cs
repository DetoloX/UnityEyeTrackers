using UnityEngine;
using System.Collections;

public class MoveToAnObjectPosition : MonoBehaviour {
	public GameObject[] posicionesObjecto;
	public float tiempoDeEspera = 10.0f;
	public float tiempoMovimiento = 3.0f;
	public bool isOvni = false;
	// Use this for initialization
	private int posicion = 0;
	private Animator animator;
	public IEnumerator Start()
	{

		animator = this.GetComponent<Animator>();
		//while (true) {

		foreach (GameObject objeto in posicionesObjecto) {

			var pointA = transform.position;
			var pointB = objeto.transform.position;
			if(isOvni) animator.ResetTrigger("isSinCoraza");
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, tiempoMovimiento));
		//	WaitForSeconds(tiempoDeEspera);
		}

			
		//	yield return StartCoroutine(MoveObject(transform, pointB, pointA, tiempoMovimiento));
		//}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
		if(isOvni) animator.SetTrigger ("isSinCoraza");
		yield return new WaitForSeconds(tiempoDeEspera);
	}
}
