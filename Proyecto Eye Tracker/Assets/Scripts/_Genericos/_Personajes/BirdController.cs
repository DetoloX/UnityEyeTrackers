using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour 
{

	private Animator anim;		//reference to the animator component
	public DestruyeGameController gameController;

	void Start()
	{
		//get reference to the animator component
		anim = GetComponent<Animator> ();

	}

	void OnTriggerEnter2D (Collider2D other) {

		 if (other.tag.ToString() == "Enemy")
		{
			anim.SetTrigger("isDestroy");
		}
	}

	void Update()
	{

	}

	void FixedUpdate()
	{
	
	}

	
	public void destroyElement(){
	
		var point = transform.position;
		point.x = -21f; 
		point.y = -4.2f; 
		transform.position = point;
		gameController.IsDie (true);
		Destroy (gameObject);


		//GameObject go = GameObject.Find("Bird");
		//go.GetComponent<MoveToAnObjectPosition> ().Start ();
	

		
	}
}
