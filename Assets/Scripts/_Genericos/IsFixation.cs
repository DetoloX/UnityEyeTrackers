using UnityEngine;
using System.Collections;

public class isFixation : MonoBehaviour {
	//public UDPReceive uDPReceive;
	private float x, y;
	private bool fixation = false; 
	public float seconds = 3;
	//public  TextMesh textMesh;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit2D (Collider2D other) {
		StopCoroutine("Countdown");
		StopAllCoroutines ();
		fixation = false;
	}



	public bool getIsFixation(){
		return fixation;

	}

	IEnumerator Countdown()
	{
		Debug.Log("entro en el countdown!");
		for (float timer = seconds; timer >= 0; timer -= Time.deltaTime)
		{
			Debug.Log(timer);
			yield return 0;
		}
		fixation = true;
		//Destroy (another.gameObject);

		another.GetComponent<Animator>().SetTrigger("isDestroy");
		//another.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(30,200), Random.Range(20,50));

	
	//	Debug.Log("Lo destruyo!");
	}

	private Collider2D another;
	void OnTriggerEnter2D (Collider2D other) {
		//x = uDPReceive.xPos; 
		//y = uDPReceive.yPos; 
		//Debug.Log("Entro!");
		if (other.tag.ToString() == "Friend")
		{
			//InvokeRepeating ("Countdown", 1.0, 1.0);
			//another = other;
			//StartCoroutine(Countdown());
			
		} else if (other.tag.ToString() == "Enemy")
		{
			another = other;
			StartCoroutine(Countdown());
		
		}

	}
}
