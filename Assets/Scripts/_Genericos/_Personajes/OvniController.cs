using UnityEngine;
using System.Collections;

public class OvniController : MonoBehaviour {
	[Header("Control de sonido")]
	public AudioClip mySound;
	public AudioSource mySource;
	public float myVolume = 1.0f;

	private Animator anim;
	private bool fixation = false;
	[Header("--------- ------------")]
	public float seconds = 3;
	public float speed = 1.0f; //how fast it shakes
	public float addTospeed = 1.01f;
	private Animation animation;
	UnityEngine.Color colores;
	private float localSpeed;
	private EnemyHealth enemyHealth;
	public DestruyeGameController gameController;
	private bool enabledToDestroy = false;
	// Use this for initialization
	void Start () {
		colores = GetComponent<ParticleSystem> ().startColor;
		anim = GetComponent<Animator> ();
		localSpeed = speed;
		GetComponent<ParticleSystem>().enableEmission= false;
		enemyHealth = this.GetComponentInChildren<EnemyHealth> ();
	
	}

	void Update () {
		if (fixation) {
			float angle = Mathf.LerpAngle(-10, 10, Mathf.PingPong(Time.time*localSpeed, 1.0f));
			transform.eulerAngles = new Vector3(0, 0, angle);
			//enemyHealth.QuitarVida(10);

			localSpeed *= addTospeed;
			}
	}


	void OnTriggerExit2D (Collider2D other) {

			StopCoroutine ("Countdown");
			StopAllCoroutines ();
			fixation = false;
			firstTime = true;
			localSpeed = speed;
			try {
				//enemyHealth.ReponeVida ();
			} catch {
			}

	}

	public bool getIsFixation(){
		return fixation;
	}
	
	IEnumerator Countdown()
	{
		fixation = true;
		float quitavida = 100*0.3f/seconds;
		for (float timer = 0; timer <= seconds; timer += Time.deltaTime)
		{
			//enemyHealth.QuitarVida(0.1f);
			yield return 0;
		}
		//gameObject.tag = "Friend";
		anim.SetTrigger("isDestroy");
	}
	
	private Collider2D another;
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag.ToString() == "Friend")
		{
			//gameObject.tag = "Friend";
			GetComponent<ParticleSystem>().enableEmission= true;
			GetComponent<ParticleSystem> ().startColor = UnityEngine.Color.white;
			GetComponent<Animator>().SetTrigger("isWinner");
		} 
		else if (other.tag.ToString() == "Aim" && enabledToDestroy)
		{
			another = other;
			StartCoroutine(Countdown());
			
		}
		
	}

	private void OnMouseExit(){
		StopCoroutine ("Countdown");
		StopAllCoroutines ();
		fixation = false;
		firstTime = true;
		localSpeed = speed;

	}
	private void OnMouseOver(){
		if (enabledToDestroy)
			CuentaAtras ();
	}

	private void CuentaAtras(){
		firstTime = false;

		StartCoroutine(Countdown());
	}
	private bool firstTime = true;
	void OnTriggerStay2D (Collider2D other) {
		//x = uDPReceive.xPos; 
		//y = uDPReceive.yPos; 
		//Debug.Log("Entro!");
		 if (other.tag.ToString() == "Aim" && enabledToDestroy)
		{	
			another = other;
			CuentaAtras();
		}
		
	}




	public void disableParticleSystem(){
		GetComponent<ParticleSystem> ().startColor = UnityEngine.Color.white;
		GetComponent<ParticleSystem>().enableEmission= false;
		
	}

	public void EnabledToDestroy(){
		enabledToDestroy = true;
	}

	
	public void DisabledToDestroy(){
		enabledToDestroy = false;
	}

	public void destroyElement(){

		gameController.addPoints ();
		GetComponent<ParticleSystem>().enableEmission= true;
		GetComponent<ParticleSystem> ().startColor = UnityEngine.Color.black;
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * 110f);
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * -250f);
		GetComponent<Rigidbody2D> ().AddTorque (145f);

		// sonido que se le aplica al explotar

		mySource.PlayOneShot( mySound, myVolume );
		StartCoroutine(DestroyObject());

	//	GetComponent<ParticleSystem> ().startColor = colores;
	//	Destroy (gameObject);

	}

	IEnumerator DestroyObject()
	{
		yield return new  WaitForSeconds(3);     //Wait one frame

		AutoDestroy();
	}

	public void AutoDestroy(){

		Destroy (gameObject);
	}
}
