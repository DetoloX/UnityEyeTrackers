using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public DestruyeGameController gameController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		 if (other.tag.ToString() == "Aim")
		{
			gameController.addCoin ();
			GetComponent<Animator>().SetTrigger("isDestroy");
		}
		
	}
	void OnMouseOver(){
		gameController.addCoin ();
		GetComponent<Animator>().SetTrigger("isDestroy");
	}

	public void destroyElement(){

		Destroy (gameObject);
		
	}

}
